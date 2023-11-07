using System.Collections.Generic;
using System.Data.Entity;

namespace DynamicSelectableList.Infrastructure
{
   public class StateContextInitializer : DropCreateDatabaseIfModelChanges<StateContext>
   {
      protected override void Seed(StateContext context)
      {
         var states = new List<State>();
         var cities = new List<City>();

         var tulaState = new State { Id = 1, Name = "����" };
         var tulaCities = new List<City>
         {
            new City {Id = 1, Name = "�������", State = tulaState, StateId = tulaState.Id},
            new City {Id = 2, Name = "�����", State = tulaState, StateId = tulaState.Id},
            new City {Id = 3, Name = "�������", State = tulaState, StateId = tulaState.Id},
            new City {Id = 4, Name = "������", State = tulaState, StateId = tulaState.Id},
            new City {Id = 5, Name = "������", State = tulaState, StateId = tulaState.Id}
         };
         tulaState.Cities = tulaCities;

         states.Add(tulaState);
         cities.AddRange(tulaCities);

         var moscowState = new State { Id = 2, Name = "������" };
         var moscowCities = new List<City>
         {
            new City {Id = 1, Name = "ٸ�����", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "������������", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "������������", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "���������", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "������", State = moscowState, StateId = moscowState.Id}
         };
         moscowState.Cities = moscowCities;

         states.Add(moscowState);
         cities.AddRange(moscowCities);

         states.ForEach(state => context.States.Add(state));
         cities.ForEach(city => context.Cities.Add(city));

         base.Seed(context);
      }
   }
}