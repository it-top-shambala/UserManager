using System.Collections.Generic;
using UserManager.Models.Table;
using Xunit;
using UserManager.Models.Item;

namespace UserManager.Models.Test;

public class TableAccountTest
{
    [Fact]
    public void GetTable_Test()
    {
        var expected = new List<Account>
        {
            new()
            {
                Id = 1,
                Login = "admin",
                Password = "123",
                RoleId = 1,
                IsActive = true
            },
            new()
            {
                Id = 2,
                Login = "user",
                Password = "123",
                RoleId = 2,
                IsActive = true
            }
        };
        var tableAccount = new TableAccount();
        var actual = tableAccount.GetTable();
        Assert.Equal(expected, actual);
    }
}
