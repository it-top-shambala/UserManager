using System.Collections.Generic;
using UserManager.Models.Item;
using UserManager.Models.Table;
using Xunit;

namespace UserManager.Models.Test;

public class TableRoleTest
{
    [Fact]
    public void GetTable_Test()
    {
        var expected = new List<Role> { new() { Id = 1, Name = "admin" }, new() { Id = 2, Name = "user" } };

        var tableRole = new TableRole();
        var actual = tableRole.GetTable();

        Assert.Equal(expected, actual);
    }
}
