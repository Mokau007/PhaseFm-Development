namespace PhaseFmApi.Models.Entities
{
	public interface IDeletable
	{
		bool IsDeleted { get; set; }

		DateTime? DateDeleted { get; set; }
	}

	public interface ICreatable
	{
		DateTime DateCreated { get; set; }
	}

	public interface IUpdatable
	{
		DateTime? DateUpdated { get; set; }
	}

	public interface IEntityPrimaryKey
	{
		object GetPrimaryKey();
	}
}
