namespace RealEstate_Dapper.Api.Dtos.ToDoListDtos
{
    public class GetByIDToDoListDto
    {
        public int ToDoListId { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
