using waterview.Data.Model;

namespace waterview.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Stations.Any())
            {
                return;
            }
            var stations = new Station[]
            {
                new Station{Name="Mississipy",FloodLevel=20,DroughtLevel=50,TimeOutInMinutes=60},
                new Station{Name="Colorado",FloodLevel=10,DroughtLevel=40,TimeOutInMinutes=60},
                new Station{Name="Rio Grande",FloodLevel=15,DroughtLevel=45,TimeOutInMinutes=120},
                new Station{Name="Arcansas",FloodLevel=4,DroughtLevel=15,TimeOutInMinutes=60},
                new Station{Name="Missouri",FloodLevel=9,DroughtLevel=14,TimeOutInMinutes=70},
            };
            context.Stations.AddRange(stations);
            context.SaveChanges();

            if (context.Values.Any())
            {
                return;
            }
            var values = new Value[]
            {
                new Value{TimeStamp=DateTime.Now.AddMinutes(-59),WaterValue=51,StationId=1},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-129),WaterValue=42,StationId=1},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-189),WaterValue=41,StationId=1},
                new Value{TimeStamp=DateTime.Now,WaterValue=7,StationId=2},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-127),WaterValue=5,StationId=2},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-187),WaterValue=4,StationId=2},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-45),WaterValue=20,StationId=3},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-129),WaterValue=24,StationId=3},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-189),WaterValue=25,StationId=3},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-58),WaterValue=6,StationId=4},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-125),WaterValue=7,StationId=4},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-185),WaterValue=8,StationId=4},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-58),WaterValue=16,StationId=5},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-125),WaterValue=13,StationId=5},
                new Value{TimeStamp=DateTime.Now.AddMinutes(-185),WaterValue=11,StationId=5},

            };
            context.Values.AddRange(values);
            context.SaveChanges();
        }
    }
}
