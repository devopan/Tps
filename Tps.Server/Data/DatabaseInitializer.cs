using Tps.Server.Data.Entities;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Project = Tps.Server.Data.Entities.Project;
using ProjectTask = Tps.Server.Data.Entities.Task;

namespace Tps.Server.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize(TpmDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Projects.Any())
            {
                return;
            }

            var projects = new Project[]
            {
            new Project{Code="Code1",Name="Name1",Client="Client1",Revenue=10.00M,StartDateTime=DateTime.Parse("2005-09-01"),EndDateTime=DateTime.Parse("2005-09-01"),Status=true},
            new Project{Code="Code2",Name="Name2",Client="Client2",Revenue=12.00M,StartDateTime=DateTime.Parse("2002-09-02"),EndDateTime=DateTime.Parse("2002-09-02"),Status=true},
            new Project{Code="Code3",Name="Name3",Client="Client3",Revenue=13.00M,StartDateTime=DateTime.Parse("2003-09-03"),EndDateTime=DateTime.Parse("2003-09-03"),Status=true},
            new Project{Code="Code4",Name="Name4",Client="Client4",Revenue=14.00M,StartDateTime=DateTime.Parse("2002-09-04"),EndDateTime=DateTime.Parse("2002-09-04"),Status=true},
            new Project{Code="Code5",Name="Name5",Client="Client5",Revenue=15.00M,StartDateTime=DateTime.Parse("2002-09-05"),EndDateTime=DateTime.Parse("2002-09-05"),Status=true},
            new Project{Code="Code6",Name="Name6",Client="Client6",Revenue=16.00M,StartDateTime=DateTime.Parse("2001-09-06"),EndDateTime=DateTime.Parse("2001-09-06"),Status=true},
            new Project{Code="Code7",Name="Name7",Client="Client7",Revenue=17.00M,StartDateTime=DateTime.Parse("2003-09-07"),EndDateTime=DateTime.Parse("2003-09-07"),Status=true},
            new Project{Code="Code8",Name="Name8",Client="Client8",Revenue=18.00M,StartDateTime=DateTime.Parse("2005-09-08"),EndDateTime=DateTime.Parse("2005-09-08"),Status=true}
            };
            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var translators = new Translator[]
            {
            new Translator{Name="Translator1"},
            new Translator{Name="Translator2"},
            new Translator{Name="Translator3"},

            };
            foreach (Translator t in translators)
            {
                context.Translators.Add(t);
            }
            context.SaveChanges();

            var tasks = new ProjectTask[]
            {
            new ProjectTask{Code="TaskCode1",JobName="JobName1",Service="Service1",VolumePages=371,Rate=31,Total=81,MarginPercent=11.00M,StartDateTime=DateTime.Parse("2005-09-01"),EndDateTime=DateTime.Parse("2005-09-01"),Status=true,ProjectId=1,TranslatorId=1},
            new ProjectTask{Code="TaskCode2",JobName="JobName2",Service="Service2",VolumePages=372,Rate=32,Total=82,MarginPercent=12.00M,StartDateTime=DateTime.Parse("2002-09-02"),EndDateTime=DateTime.Parse("2002-09-02"),Status=true,ProjectId=2,TranslatorId=2},
            new ProjectTask{Code="TaskCode3",JobName="JobName3",Service="Service3",VolumePages=373,Rate=33,Total=83,MarginPercent=13.00M,StartDateTime=DateTime.Parse("2003-09-03"),EndDateTime=DateTime.Parse("2003-09-03"),Status=true,ProjectId=3,TranslatorId=3},
            new ProjectTask{Code="TaskCode4",JobName="JobName4",Service="Service4",VolumePages=374,Rate=34,Total=84,MarginPercent=14.00M,StartDateTime=DateTime.Parse("2002-09-04"),EndDateTime=DateTime.Parse("2002-09-04"),Status=true,ProjectId=4,TranslatorId=1},
            new ProjectTask{Code="TaskCode5",JobName="JobName5",Service="Service5",VolumePages=375,Rate=35,Total=85,MarginPercent=15.00M,StartDateTime=DateTime.Parse("2002-09-05"),EndDateTime=DateTime.Parse("2002-09-05"),Status=true,ProjectId=5,TranslatorId=2},
            new ProjectTask{Code="TaskCode6",JobName="JobName6",Service="Service6",VolumePages=376,Rate=36,Total=86,MarginPercent=16.00M,StartDateTime=DateTime.Parse("2001-09-06"),EndDateTime=DateTime.Parse("2001-09-06"),Status=true,ProjectId=6,TranslatorId=3},
            new ProjectTask{Code="TaskCode7",JobName="JobName7",Service="Service7",VolumePages=377,Rate=37,Total=87,MarginPercent=17.00M,StartDateTime=DateTime.Parse("2003-09-07"),EndDateTime=DateTime.Parse("2003-09-07"),Status=true,ProjectId=7,TranslatorId=1}
            };
            foreach (ProjectTask t in tasks)
            {
                context.Tasks.Add(t);
            }
            context.SaveChanges();
        }
    }
}
