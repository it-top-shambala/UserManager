using System.Collections.Generic;
using UserManager.Models.Table;
using Xunit;
using UserManager.Models.Item;

namespace UserManager.Models.Test;

public class TableUserTest
{
    [Fact]
    public void GetTable_Test()
    {
        var expected = new List<User>
        {
            new()
            {
                Id = 1,
                FirstName = "anonim",
                LastName = "anonimus",
                Email = "add@admin.ru",
                PhotoUrl = "url"
            },
            new()
            {
                Id = 2,
                FirstName = "user",
                LastName = "anonimus",
                Email = "user@admin.ru",
                PhotoUrl = "url"
            }
        };
        var tableUser = new TableUser();
        var actual = tableUser.GetTable();
        Assert.Equal(expected, actual);
    }
}
