using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaseFmApi.Migrations
{
    /// <inheritdoc />
    public partial class DbAduditTrailAttributesToAllEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "phasefm");

            migrationBuilder.CreateTable(
                name: "article",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateGenerated = table.Column<DateTime>(type: "date", nullable: false),
                    ArticleContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "businessdetail",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessdetail_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "discount",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employeetype",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeetype_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "event",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "letter",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecipientLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateGenerated = table.Column<DateTime>(type: "date", nullable: false),
                    LetterContent = table.Column<string>(type: "text", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_letter_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "music",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SongName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AlbumName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Composer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RecordLabel = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_music_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "musicrequeststatus",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musicrequeststatus_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "musicsubmissionstatus",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musicsubmissionstatus_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orderreceivedstatus",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderreceivedstatus_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orderstatus",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderstatus_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "playlist",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productcategory",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productcategory_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "quotation",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateGenerated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "radio",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radio_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "show",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_show_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vat",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vat_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_employeetype",
                        column: x => x.EmployeeTypeId,
                        principalSchema: "phasefm",
                        principalTable: "employeetype",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "musicrequest",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DateRequested = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musicrequest_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musicrequest_musicrequeststatus",
                        column: x => x.StatusId,
                        principalSchema: "phasefm",
                        principalTable: "musicrequeststatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "musicsubmission",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Composer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RecordLabel = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musicsubmission_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musicsubmission_musicsubmissionstatus",
                        column: x => x.StatusId,
                        principalSchema: "phasefm",
                        principalTable: "musicsubmissionstatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "playlistmusic",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PlayListId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlistmusic_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playlistmusic_music",
                        column: x => x.MusicId,
                        principalSchema: "phasefm",
                        principalTable: "music",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_playlistmusic_playlist",
                        column: x => x.PlayListId,
                        principalSchema: "phasefm",
                        principalTable: "playlist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "producttype",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producttype_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producttype_productcategory",
                        column: x => x.ProductCategoryId,
                        principalSchema: "phasefm",
                        principalTable: "productcategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "quoteline",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerUnit = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quoteline_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quoteline_quotation",
                        column: x => x.QuotationId,
                        principalSchema: "phasefm",
                        principalTable: "quotation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "radioshow",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RadioId = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radioshow_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_radioshow_radio",
                        column: x => x.RadioId,
                        principalSchema: "phasefm",
                        principalTable: "radio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_radioshow_show",
                        column: x => x.ShowId,
                        principalSchema: "phasefm",
                        principalTable: "show",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "address",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_address_user",
                        column: x => x.UserId,
                        principalSchema: "phasefm",
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "order",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    OrderReceivedStatusId = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_orderreceivedstatus",
                        column: x => x.OrderReceivedStatusId,
                        principalSchema: "phasefm",
                        principalTable: "orderreceivedstatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_order_orderstatus",
                        column: x => x.OrderStatusId,
                        principalSchema: "phasefm",
                        principalTable: "orderstatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_order_user",
                        column: x => x.UserId,
                        principalSchema: "phasefm",
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_productcategory",
                        column: x => x.ProductCategoryId,
                        principalSchema: "phasefm",
                        principalTable: "productcategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_product_producttype",
                        column: x => x.ProductTypeId,
                        principalSchema: "phasefm",
                        principalTable: "producttype",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "basket",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basket_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_basket_product",
                        column: x => x.ProductId,
                        principalSchema: "phasefm",
                        principalTable: "product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_basket_user",
                        column: x => x.UserId,
                        principalSchema: "phasefm",
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "orderline",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderline_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderline_product",
                        column: x => x.ProductId,
                        principalSchema: "phasefm",
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "productcolor",
                schema: "phasefm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productcolor_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productcolor_color",
                        column: x => x.ColorId,
                        principalSchema: "phasefm",
                        principalTable: "color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productcolor_product",
                        column: x => x.ProductId,
                        principalSchema: "phasefm",
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_UserId",
                schema: "phasefm",
                table: "address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_basket_ProductId",
                schema: "phasefm",
                table: "basket",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_basket_UserId",
                schema: "phasefm",
                table: "basket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_EmployeeTypeId",
                schema: "phasefm",
                table: "employee",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_musicrequest_StatusId",
                schema: "phasefm",
                table: "musicrequest",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_musicsubmission_StatusId",
                schema: "phasefm",
                table: "musicsubmission",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_order_OrderReceivedStatusId",
                schema: "phasefm",
                table: "order",
                column: "OrderReceivedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_order_OrderStatusId",
                schema: "phasefm",
                table: "order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserId",
                schema: "phasefm",
                table: "order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_orderline_ProductId",
                schema: "phasefm",
                table: "orderline",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_playlistmusic_MusicId",
                schema: "phasefm",
                table: "playlistmusic",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_playlistmusic_PlayListId",
                schema: "phasefm",
                table: "playlistmusic",
                column: "PlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductCategoryId",
                schema: "phasefm",
                table: "product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductTypeId",
                schema: "phasefm",
                table: "product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_productcolor_ColorId",
                schema: "phasefm",
                table: "productcolor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_productcolor_ProductId",
                schema: "phasefm",
                table: "productcolor",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_producttype_ProductCategoryId",
                schema: "phasefm",
                table: "producttype",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_quoteline_QuotationId",
                schema: "phasefm",
                table: "quoteline",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_radioshow_RadioId",
                schema: "phasefm",
                table: "radioshow",
                column: "RadioId");

            migrationBuilder.CreateIndex(
                name: "IX_radioshow_ShowId",
                schema: "phasefm",
                table: "radioshow",
                column: "ShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "article",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "basket",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "businessdetail",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "delivery",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "discount",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "employee",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "event",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "letter",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "musicrequest",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "musicsubmission",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "order",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "orderline",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "playlistmusic",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "productcolor",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "quoteline",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "radioshow",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "vat",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "employeetype",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "musicrequeststatus",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "musicsubmissionstatus",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "orderreceivedstatus",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "orderstatus",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "user",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "music",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "playlist",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "color",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "product",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "quotation",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "radio",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "show",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "producttype",
                schema: "phasefm");

            migrationBuilder.DropTable(
                name: "productcategory",
                schema: "phasefm");
        }
    }
}
