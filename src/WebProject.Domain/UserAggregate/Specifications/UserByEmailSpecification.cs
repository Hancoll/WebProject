using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain.Common;

namespace WebProject.Domain.UserAggregate.Specifications;

public class UserByEmailSpecification : Specification<User>
{
    private readonly string email;

    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.Email == email;
    }

    public UserByEmailSpecification(string email) => this.email = email;
}
