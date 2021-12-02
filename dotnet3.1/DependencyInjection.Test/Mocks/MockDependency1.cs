using DependencyInjection.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Test.Mocks
{
    public class MockDependency1 : IDependency1
    {
        public string GetPrettyJsonOfOptions()
        {
            return "{ \"mockedOutput\": true }";
        }
    }
}
