namespace task1_Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            FinancialDepartment f1 = new FinancialDepartment(100, "Fiancial Tech1");
            FinancialDepartment f2 = new FinancialDepartment(101, "Financial Tech2");
            HeadDepartment Head1 = new (1,"Head1");
            Head1.addDepartment(f1);
            Head1.addDepartment(f2);


            SalesDepartment s1 = new SalesDepartment(200, "Sales Tech1");
            SalesDepartment s2 = new SalesDepartment(201, "Sales Tech2");

            HeadDepartment Head2 = new HeadDepartment(2,"Head2");
            Head2.addDepartment(s1);
            Head2.addDepartment(s2);

            HeadDepartment Head3 = new HeadDepartment(3,"Head3");
            Head3.addDepartment(Head1);
            Head3.addDepartment(Head2);
            Head3.printDepartmentName();


        }
    }
}