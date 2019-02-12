using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Collections.Generic;

namespace PadawansTask13.Tests
{
  [TestFixture]
  public class HiddenTest
  {
    private readonly string[] _fields = { "surname", "age" };

    [Test]
    public void Employee_Class_Is_Created()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      Assert.IsNotNull(employeeType, "'Employee' class is not created.");
    }

    [Test]
    public void All_Fields_Are_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();
      var notDefinedFields = new List<string>();

      var employeeFields = this.GetAllNonPublicFields(assemblyContent);
      foreach (var field in _fields)
      {
        var instanceField = employeeFields.FirstOrDefault(f => f.Name.ToLower().Contains(field));
        if (instanceField == null)
        {
          notDefinedFields.Add(field);
        }   
      }

      if (notDefinedFields.Count == 0)
      {
        notDefinedFields = null;
      }

      Assert.IsNull(notDefinedFields, $"Fields: {notDefinedFields?.Aggregate((previous, next) => $"'{previous}', {next}")} are not defined.");
    }

    [Test]
    public void All_Fields_Are_Private()
    {
      var assemblyContent = this.LoadAssemblyContent();
      var notPrivateFields = new List<string>();

      var employeeFields = this.GetAllNonPublicFields(assemblyContent);
      foreach (var field in _fields)
      {
        var employeeField = employeeFields.FirstOrDefault(f => f.Name.ToLower().Contains(field));
        if (employeeField == null)
        {
          notPrivateFields.Add(field);
        }
      }

      if (notPrivateFields.Count == 0)
      {
        notPrivateFields = null;
      }

      Assert.IsNull(notPrivateFields, $"Fields: {notPrivateFields?.Aggregate((previous, next) => $"{previous}, {next}")} are not private.");
    }

    [Test]
    public void Default_Contstructor_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));
      var defaultConstructor = employeeType?.GetConstructor(new Type[] { });

      Assert.IsNotNull(defaultConstructor, "Default contstructor is not defined.");
    }

    [Test]
    public void Parametrized_Constructor_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var constructor = employeeType?.GetConstructors().FirstOrDefault(c =>
      {
        var parameters = c.GetParameters();
        if (parameters.Length > 0 &&
                  parameters.Count(p => p.ParameterType == typeof(string)) == 1 &&
                  parameters.Count(p => p.ParameterType == typeof(int)) == 1)
        {
          return true;
        }

        return false;
      });

      Assert.IsNotNull(constructor, "Parametrized contstructor with two 'string' and one 'int' parameters is not defined.");
    }

    [Test]
    public void Private_Method_With_String_Return_Type_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var method = employeeType?.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
          .FirstOrDefault(m => m.ReturnType == typeof(string) && m.IsPrivate);

      Assert.IsNotNull(method, "Private method with string return type is not defined.");
    }

    [Test]
    public void Public_Set_Surname_Method_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var method = employeeType?.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
          .FirstOrDefault(m =>
          {
            if (m.ReturnType == typeof(void) && m.GetParameters().All(p => p.ParameterType == typeof(string)))
            {
              return true;
            }

            return false;
          });

      Assert.IsNotNull(method, "Public set surname method is not defined");
    }

    [Test]
    public void Public_Get_Employee_Info_Method_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var method = employeeType?.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
          .FirstOrDefault(m =>
          {
            if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
            {
              return true;
            }

            return false;
          });

      Assert.IsNotNull(method, "Public get employee info method is not defined");
    }

    [Test]
    public void Get_Employee_Information()
    {
      var surname = "Ivanov";
      var age = 25;
      var infoTemplate = $"Surname: {surname}, Age: {age}";

      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent?.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var constructor = employeeType?.GetConstructors().FirstOrDefault(c =>
      {
        var parameters = c.GetParameters();
        if (parameters.Length > 0 &&
                  parameters.Count(p => p.ParameterType == typeof(string)) == 1 &&
                  parameters.Count(p => p.ParameterType == typeof(int)) == 1)
        {
          return true;
        }

        return false;
      });

      var values = constructor?.GetParameters()
        .Select(p =>
        {
          if (p.ParameterType == typeof(string))
          {
            return surname as object;
          }
          if (p.ParameterType == typeof(int))
          {
            return age as object;
          }

          return null;
        }).ToArray();

      if (employeeType != null)
      {
        var employeeInstance = Activator.CreateInstance(employeeType, values);
        var getInfoMethod = employeeType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
          .FirstOrDefault(m =>
          {
            if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
            {
              return true;
            }

            return false;
          });

        var info = getInfoMethod?.Invoke(employeeInstance, new object[0]);
        Assert.AreEqual(
          infoTemplate,
          info?.ToString(),
          $"Actual result - '{info}' does not match to expected result - '{infoTemplate}'");
      }

      Assert.NotNull(employeeType, "'Employee' type is not created?");
      Assert.NotNull(constructor, "'Employee' does not contain parametrized constructor?");
    }

    [Test]
    public void Set_New_Surname_And_Get_Employee_Info()
    {
      var surname = "Ivanov";
      var newSurname = "Sidorov";
      var age = 25;
      var infoTemplate = $"Surname: {newSurname}, Age: {age}";

      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent?.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var constructor = employeeType?.GetConstructors().FirstOrDefault(c =>
      {
        var parameters = c.GetParameters();
        if (parameters.Length > 0 &&
                  parameters.Count(p => p.ParameterType == typeof(string)) == 1 &&
                  parameters.Count(p => p.ParameterType == typeof(int)) == 1)
        {
          return true;
        }

        return false;
      });

      var values = constructor?.GetParameters()
        .Select(p =>
        {
          if (p.ParameterType == typeof(string))
          {
            return surname as object;
          }
          if (p.ParameterType == typeof(int))
          {
            return age as object;
          }

          return null;
        }).ToArray();

      if (employeeType != null)
      {
        var employeeInstance = Activator.CreateInstance(employeeType, values);
        var publicMethods =
          employeeType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        var setNewSurnameMethod = publicMethods.FirstOrDefault(m =>
        {
          var parameters = m.GetParameters();
          if (m.ReturnType == typeof(void) &&
            parameters.Length == 1 &&
            parameters[0].ParameterType == typeof(string))
          {
            return true;
          }

          return false;
        });

        setNewSurnameMethod?.Invoke(employeeInstance, new object[] { newSurname });

        var getInfoMethod = publicMethods.FirstOrDefault(m =>
        {
          if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
          {
            return true;
          }

          return false;
        });

        var info = getInfoMethod?.Invoke(employeeInstance, new object[0]);
        Assert.AreEqual(
          infoTemplate,
          info?.ToString(),
          $"Actual result - '{info}' does not match to expected result - '{infoTemplate}'");
      }

      Assert.NotNull(employeeType, "'Employee' type is not created?");
      Assert.NotNull(constructor, "'Employee' does not contain parametrized constructor?");
    }

    private Assembly LoadAssemblyContent()
    {
      return Assembly.GetExecutingAssembly();
    }

    private FieldInfo[] GetAllNonPublicFields(Assembly assemblyContent)
    {
      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      return employeeType?.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
    }
  }
}
