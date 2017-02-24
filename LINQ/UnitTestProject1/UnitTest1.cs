using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly List<User> _userListFirst = new List<User>
        {
            new User
            {
                Age = 21,
                Gender = Gender.Man,
                Name = "User1",
                Salary = 21000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 18,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 19000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Ann",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            }
        };

        private readonly List<User> _userListSecond = new List<User>
        {
            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            },
            new User
            {
                Age = 28,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 21000
            }
        };

        [TestMethod]
        public void SortByName()
        {
            var actualDataFirstList = new List<User>();
            var expectedData = _userListFirst[4];

            actualDataFirstList = _userListFirst;
            actualDataFirstList = actualDataFirstList.OrderBy(x=>x.Name).ToList();
            Assert.IsTrue(actualDataFirstList[0].Equals(expectedData));
        }

        [TestMethod]
        public void SortByNameDescending()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = _userListFirst[0];

            //ToDo Add code first list
            actualDataSecondList = _userListFirst;
            actualDataSecondList = actualDataSecondList.OrderByDescending(x => x.Name).ToList();

            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
            
        }

        [TestMethod]
        public void SortByNameAndAge()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = _userListSecond[5];

            //ToDo Add code second list
            actualDataSecondList = _userListSecond;
            actualDataSecondList = actualDataSecondList.OrderBy(x => x.Name).ThenBy(x=>x.Age).ToList();

            Assert.IsTrue(actualDataSecondList[1].Equals(expectedData));
        }

        [TestMethod]
        public void RemovesDuplicate()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = new List<User> {_userListSecond[0], _userListSecond[1], _userListSecond[3], _userListSecond[4],_userListSecond[5]};

            //ToDo Add code second list

            actualDataSecondList = _userListSecond.Distinct().ToList();
            
            CollectionAssert.AreEqual(expectedData, actualDataSecondList);
        }

        [TestMethod]
        public void ReturnsDifferenceFromFirstAndSecondList()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { _userListFirst[0], _userListFirst[2], _userListFirst[3] };

            //ToDo Add code first list and second

            actualData = _userListFirst.Except(_userListSecond).ToList();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void SelectsValuesByNameMax()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { _userListSecond[0], _userListSecond[2] };
            string name = "Max";

            //ToDo Add code for second list
            //Find all users with name 'Max'
            actualData = _userListSecond.FindAll(x=>x.Name == name).ToList();


            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void ContainOrNotContainName()
        {
            var isContain = false;


            //name max 
            //ToDo Add code for second list
            string name = "Max";
            isContain = _userListSecond.Contains(_userListSecond.Find(u => u.Name == name));

            Assert.IsTrue(isContain);


            // name obama
            //ToDo add code for second list
            name = "obama";
            isContain = _userListSecond.Contains(_userListSecond.Find(u => u.Name == name));

            Assert.IsFalse(isContain);
        }

        [TestMethod]
        public void AllListWithName()
        {
            var isAll = false;
            //name max 
            //ToDo Add code for second list
            isAll = _userListSecond.All(e => e.Name == "Max");

            Assert.IsFalse(isAll);
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameMax()
        {
            var actualData = new User();
            
            try
            {
                //ToDo Add code for second list
                //name Max
                _userListSecond.Single(u => u.Name == "Max");
                Assert.Fail("Fail");
            }
            catch (InvalidOperationException ie)
            {
                //Assert.AreEqual("Sequence contains more than one matching element", ie.Message);
                Assert.AreEqual("Последовательность содержит более одного соответствующего элемента", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd
                _userListSecond.Single(u => u.Name == "Ldfsdfsfd");

                Assert.Fail("Fail");
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Последовательность не содержит соответствующий элемент", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsOnlyElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list
             //name Ldfsdfsfd
            actualData = _userListSecond.SingleOrDefault(u => u.Name == "Ldfsdfsfd");

            Assert.IsTrue(actualData == null);
        }


        [TestMethod]
        public void ReturnsTheFirstElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd
                actualData = _userListSecond.First(u => u.Name == "Ldfsdfsfd");

                Assert.Fail("Fail");
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Последовательность не содержит соответствующий элемент", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsTheFirstElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list
            //name Ldfsdfsfd
            actualData = _userListSecond.FirstOrDefault(u => u.Name == "Ldfsdfsfd");
            Assert.IsTrue(actualData == null);
        }

        [TestMethod]
        public void GetMaxSalaryFromFirst()
        {
            var expectedData = 54000;
            var actualData = new User();

            //ToDo Add code for first list
            var max = _userListFirst.Max(u => u.Salary);
            actualData = _userListFirst.Find(u => u.Salary == max);

            Assert.IsTrue(expectedData == actualData.Salary);
        }

        [TestMethod]
        public void GetCountUserWithNameMaxFromSecond()
        {
            var expectedData = 2;
            var actualData = 0;

            //ToDo Add code for second list
            actualData = _userListSecond.FindAll(u => u.Name == "Max").Count;

            Assert.IsTrue(expectedData == actualData);
        }

        [TestMethod]
        public void Join()
        {
            var NameInfo = new[]
            {
                new {name = "Max", Info = "info about Max"},
                new {name = "Alan", Info = "About Alan"},
                new {name = "Alex", Info = "About Alex"}
            }.ToList();

            var expectedData = 3;
            var actualData = -1;

            //ToDo Add code for second list
            actualData = (from user in _userListSecond
                        join info in NameInfo
                        on user.Name
                        equals info.name
                        select new User()).Count();

            Assert.IsTrue(expectedData == actualData);
        }
    }
}
