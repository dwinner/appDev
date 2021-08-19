﻿using Microsoft.WindowsAPICodePack.Sensors;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AmbientSensorDemo
{
   public partial class Form1 : Form
   {
      private Guid _currentSensor;

      public Form1()
      {
         InitializeComponent();
         SensorManager.SensorsChanged += SensorManager_SensorsChanged;
      }

	   private void SensorManager_SensorsChanged(SensorsChangedEventArgs change)
      {
         BeginInvoke(new MethodInvoker(PopulateData));
      }

      private void PopulateData()
      {
         try
         {
            SensorManager.GetSensorsByTypeId<AmbientLightSensor>();
            _currentSensor = new Guid("b4133ea3-c284-4626-a6e3-10bfaf50299f");
            var sensor = SensorManager.GetSensorBySensorId<AmbientLightSensor>(_currentSensor);
            lblSensor.Text = "SensorId = " + sensor.SensorId;
            var current = sensor.CurrentLuminousIntensity.Intensity;
            prgSensorProgress.Value = Math.Min((int)current, prgSensorProgress.Maximum);
            // Set up automatc data report handling.
            sensor.AutoUpdateDataReport = true;
            sensor.DataReportChanged += DataReportChanged;
         }
         catch (SensorPlatformException ex)
         {
            Debug.Write("Sensor Id not found :" + ex.Message);
         }
      }

	   private void DataReportChanged(Sensor sender, EventArgs e)
      {
         var ambientLightSensor = sender as AmbientLightSensor;
         BeginInvoke(new MethodInvoker(delegate
         {
            // report data (clamp value to progress bar maximum )
	         if (ambientLightSensor != null)
	         {
		         var current = ambientLightSensor.CurrentLuminousIntensity.Intensity;
		         prgSensorProgress.Value = Math.Min((int)current, prgSensorProgress.Maximum);
	         }
         }));
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         try
         {
            // ask for sensor permission if needed
            var sl = SensorManager.GetAllSensors();
            SensorManager.RequestPermission(Handle, true, sl);
         }
         catch (SensorPlatformException ex)
         {
            MessageBox.Show(ex.Message);
            Environment.Exit(0);
         }
      }
   }
}