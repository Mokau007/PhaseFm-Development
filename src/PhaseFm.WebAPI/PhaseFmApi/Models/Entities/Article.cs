using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhaseFmApi.Models.Entities;

public partial class Article : IDeletable, ICreatable, IUpdatable,IEntityPrimaryKey
{
	[Key] 
	public int Id { get; set; }

  public DateOnly DateGenerated { get; set; }

  public string ArticleContent { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

  public object GetPrimaryKey()
  {
		return Id;
  }
}
