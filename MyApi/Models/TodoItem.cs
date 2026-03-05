namespace MyApi.Models;


public class TodoItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set;  } = string.Empty;

    private bool _done;

    public bool Done
    {
        get => _done;
        set
        {
            if(value && !done)
            {
                throw Exception();
            }
            _done = value;
        }

    }

    public TodoList List { get; set;}
}