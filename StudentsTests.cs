using MyFirstApp;
using Newtonsoft.Json.Linq;
using Project1;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SchoolTestProject
{
    [TestFixture]
    public class StudentsTests : BaseTests
    {
        [Test]
        [Description("Validate the students don't have IDs")]
        public void ValidateNoIDs()
        {
            foreach (var studentJObject in Array)
            {
                JObject jObjectItem = studentJObject.ToObject<JObject>();
                Assert.False(jObjectItem.ContainsKey("Id"), "Each student has such a property!");
            }
        }

        [Test]
        [Description("Validate each students has unique ID property")]
        public void ValidateIdPresense()
        {
            List<JObject> studentsWithOutIDs = Array.ToObject<List<JObject>>();
            List<JObject> studentsListWithIds = AddStudentId(studentsWithOutIDs);


            List<JToken> idList = new List<JToken>();

            foreach (var studentJObject in studentsListWithIds)
            {
                JObject jObjectItem = studentJObject.ToObject<JObject>();
                Assert.True(jObjectItem.ContainsKey("Id"), "Missing property!");
                idList.Add(studentJObject.GetValue("Id"));
            }

            bool isUnique = idList.Distinct().Count() == idList.Count();
            Assert.True(isUnique, "Students'IDs are not unique");
        }

        [Test]
        [Description("Third test")]
        public void Thirdtest()
        { 
        }
    }
}