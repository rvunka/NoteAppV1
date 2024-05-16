using NUnit.Framework;
using NoteAppV1;

namespace NoteAppV1.UnitTest
{
    [TestFixture]
    public class NoteTest
    {
        [Test]
        public void TestSetName_Incorrect_50()
        {
            Note note = new Note("", NoteCategory.Разное.ToString(), "");
            bool isException = false;
            try
            {
                note.Name = new string('q', 51);
            }
            catch (ArgumentException)
            {
                isException = true;
            }
            Assert.AreEqual(true, isException);
        }

        [Test]
        public void TestSetName_Null()
        {
            Note note = new Note("", NoteCategory.Разное.ToString(), "");
            Assert.AreEqual("Без названия", note.Name);
        }

        [Test]
        public void TestSetName()
        {
            Note note = new Note("Имя", NoteCategory.Разное.ToString(), "");
            Assert.AreEqual("Имя", note.Name);
        }

        [Test]
        public void TestCategory()
        {
            Note note = new Note("", NoteCategory.Разное.ToString(), "");
            Assert.AreEqual(NoteCategory.Разное, note.Category);
        }

        [Test]
        public void TestText()
        {
            Note note = new Note("", NoteCategory.Разное.ToString(), "Текст");
            Assert.AreEqual("Текст", note.Text);
        }

        [Test]
        public void TestTimeOfCreation()
        {
            Note note = new Note("", NoteCategory.Разное.ToString(), "");
            Assert.AreEqual(DateTime.Now, note.CreateTime);
        }

        [Test]
        public void TestTimeOfModification()
        {
            Note note = new Note("", NoteCategory.Разное.ToString(), "");
            Assert.AreEqual(DateTime.Now, note.LastModifedTime);
        }
    }
}