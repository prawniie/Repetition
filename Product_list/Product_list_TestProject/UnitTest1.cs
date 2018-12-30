using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Product_list_TestProject
{
    [TestClass]
    public class UnitTest1
    {
        ValidInput x = new ValidInput();

        [TestMethod]
        public void should_return_true_when_name_consists_of_letters_followed_by_digits()
        {
            bool result = x.CheckIfInputIsValid2("lg-350");
            bool expected = true;

            Assert.AreEqual(result,expected);
        }

        [TestMethod]
        public void should_return_true_when_digits_are_between_200_and_500()
        {
            bool result = x.CheckIfInputIsValid("lgx-205");
            bool expected = true;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("lg-150")]
        [DataRow("lg-550")]
        //[DataRow(null)]
        public void should_return_false_when_digits_are_lower_than_200_or_larger_than_500(string input)
        {
            Assert.IsFalse(x.CheckIfInputIsValid(input));
    }

        [TestMethod]
        public void should_return_false_when_name_is_empty()
        {
            bool result = x.CheckIfInputIsValid("");
            bool expected = false;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void should_return_false_when_name_has_no_bindestreck()
        {
            bool result = x.CheckIfInputIsValid("marsvin800");
            bool expected = false;

            Assert.AreEqual(result,expected);
        }
    }
}
