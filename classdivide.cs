public class Node<T>
{
    private T value;
    private Node<T> next;
    public Node(T value)
    {
        this.value = value;
        this.next = null;
    }
    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }
    public T GetValue()
    {
        return value;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }
    public Node<T> GetNext()
    {
        return next;
    }
    public void SetNext(Node<T> next)
    {
        this.next = next;
    }
    public bool HasNext()
    {
        return this.next != null;
    }
    public override string ToString()
    {
        return this.value + " --> " + this.next;
    }
}
public class Date
{
    private int day;
    private int month;
    private int year;
    public Date(int day, int month, int year)
    {
        this.day = day; this.month = month; this.year = year;
    }
    public void SetDay(int day) { this.day = day; }
    public void SetMonth(int Month) { this.month = Month; }
    public void SetYear(int year) { this.year = year; }
    public int GetDay() { return this.day; }
    public int GetMonth() { return this.month; }
    public int Getyear() { return this.year; }
    public string fulldate() { return "" + this.year + " " + this.month + " " + this.day + "\n"; }
}
public class Student
{
    private string firstname;
    private string lastname;
    private Date dateOfBirth;
    public Student(string fn, string ln, Date d)
    {
        this.firstname = fn; this.lastname = ln; this.dateOfBirth = d;
    }
    public string GetFirst() { return this.firstname; }
    public string GetLast() { return this.lastname; }
    public Date GetDate() { return this.dateOfBirth; }
    public void SetFirst(string first) { this.firstname = first; }
    public void SetLast(string last) { this.lastname = last; }
    public void SetDate(Date data) { this.dateOfBirth = data; }
}
public class code
{
    public static Node<Student> split(Node<Student> list)
    {
        Node<Student> temp = list;
        Node<Student> node = temp;
        Node<Student> node2 = null;
        Node<Student> node3 = null;
        while (node != null)
        {
            if (node.GetValue().GetDate().GetMonth() >= 6)
            {
                if (node2 == null)
                {
                    node2 = node;
                    node3 = node2;
                }
                else
                {
                    node3.SetNext(node);
                    node3 = node3.GetNext();

                }
                temp.SetNext(node.GetNext());
                node = temp;
                node = node.GetNext();
            }
            else { temp = node; node = node.GetNext(); }
        }
        return node2;
    }
    public static void Main(string[] args)
    {
        Node<Student> listofstud = new Node<Student>(new Student("yuval", "lupo", new Date(1, 2, 2007)));
        int i = 0;
        Node<Student> temp = null;
        Random randomNum = new Random();
        int randday;
        int ranmon;
        while (i < 10)
        {
            i++;
            randday = randomNum.Next(1, 32);
            ranmon = randomNum.Next(1, 13);
            if (listofstud.GetNext() == null)
            {
                listofstud.SetNext(new Node<Student>(new Student("yuval", "lupo", new Date(randday, ranmon, 2007))));
                temp = listofstud.GetNext();
            }
            else if (temp.GetNext() == null)
            {
                temp.SetNext(new Node<Student>(new Student("yuval", "lupo", new Date(randday, ranmon, 2007))));
                temp = temp.GetNext();
            }
        }
        Node<Student> list2=split(listofstud);
    }
}
