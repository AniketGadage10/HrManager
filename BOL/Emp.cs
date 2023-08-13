namespace BOL
{
    public enum Department
    {
        HR,SALES,MANAGER
    }
    public class Emp
    {

        public int ? eid  { get; set; }
        public string ? name { get; set; }
        public String ? email { get; set; }
   
        public String ? psw { get; set; }
        public Department department { get; set; }
        public DateOnly date { get; set; }

        public Emp() { }

        public Emp(int eid,String name,String email,String psw,Department department, DateOnly date)
        {
            this.eid = eid;
            this.name = name;
            this.email = email; 
            this.psw = psw;
            this.department = department;
            this.date = date;
        }     
        public override string ToString()
        {
            return " | " + this.eid + " | " + this.name + " | " + this.email + " | "
                 + this.department.ToString() + " | " + this.psw + " | " + this.date + " | " + this.psw;
        }
    }
}