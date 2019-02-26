using System;
namespace Grades
{
    // Defines the types of methods this can accept (based on method signature)
    // Accepts methods that return void and accepts the sender object and NamedChangedArgs object

    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
