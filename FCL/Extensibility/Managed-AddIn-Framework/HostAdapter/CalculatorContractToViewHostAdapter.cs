﻿using System.AddIn.Pipeline;
using System.Collections.Generic;
using CalcContract;
using HostAdapter.Properties;
using HostView;

namespace HostAdapter
{
   [HostAdapter]
   // ReSharper disable once UnusedMember.Global
   internal class CalculatorContractToViewHostAdapter : Calculator
   {
      private readonly ICalculatorContract _contract;

      // ReSharper disable once NotAccessedField.Local
      [UsedImplicitly] private ContractHandle _handle;

      public CalculatorContractToViewHostAdapter(ICalculatorContract contract)
      {
         _contract = contract;
         _handle = new ContractHandle(contract);
      }

      public override IList<Operation> GetOperations()
      {
         return CollectionAdapters.ToIList(_contract.GetOperations(), OperationHostAdapters.ContractToViewAdapter,
            OperationHostAdapters.ViewToContractAdapter);
      }

      public override double Operate(Operation operation, params double[] operands)
      {
         return _contract.Operate(OperationHostAdapters.ViewToContractAdapter(operation), operands);
      }
   }
}