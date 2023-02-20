using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ksiegarnia.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorzy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorzy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dostepnosc = table.Column<int>(type: "int", nullable: false),
                    CzyWOfercie = table.Column<bool>(type: "bit", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sciezka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ceny",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wartosc = table.Column<float>(type: "real", nullable: false),
                    CzyPromocja = table.Column<bool>(type: "bit", nullable: false),
                    KsiazkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceny", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ceny_Ksiazki_KsiazkaId",
                        column: x => x.KsiazkaId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KsiazkaAutor",
                columns: table => new
                {
                    KsiazkaId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsiazkaAutor", x => new { x.KsiazkaId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_KsiazkaAutor_Autorzy_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autorzy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KsiazkaAutor_Ksiazki_KsiazkaId",
                        column: x => x.KsiazkaId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KsiazkaKategoria",
                columns: table => new
                {
                    KsiazkaId = table.Column<int>(type: "int", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsiazkaKategoria", x => new { x.KsiazkaId, x.KategoriaId });
                    table.ForeignKey(
                        name: "FK_KsiazkaKategoria_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KsiazkaKategoria_Ksiazki_KsiazkaId",
                        column: x => x.KsiazkaId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autorzy",
                columns: new[] { "Id", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Jenny", "Blackhurst" },
                    { 2, "Paula", "Hawkings" },
                    { 3, "Andy", "Weir" },
                    { 4, null, "Daveniss" },
                    { 5, "Diego", "Agrimbau" },
                    { 6, "Lucas", "Varela" }
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Fantastyka" },
                    { 2, "Kryminał" },
                    { 3, "Science Fiction" },
                    { 4, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Ksiazki",
                columns: new[] { "Id", "CzyWOfercie", "Dostepnosc", "Opis", "Sciezka", "Tytul" },
                values: new object[,]
                {
                    { 1, true, 15, "To był najszczęśliwszy dzień w jej życiu. Co więc sprawiło, że skoczyła? Tej nocy stała na klifie i patrzyła w dół, na fale, tak jak dziesiątki razy wcześniej. Ale tym razem było inaczej – miała na sobie suknię ślubną, na rozwianych blond włosach welon i… tym razem skoczyła.", "/images/1.jpg", "Noc, kiedy umarła" },
                    { 2, true, 4, "Rachel każdego ranka dojeżdża do pracy tym samym pociągiem. Wie, że pociąg zawsze zatrzymuje się przed tym samym semaforem, dokładnie naprzeciwko szeregu domów. Zaczyna się jej nawet wydawać, że zna ludzi, którzy mieszkają w jednym z nich. Uważa, że prowadzą doskonałe życie. Gdyby tylko mogła być tak szczęśliwa jak oni.", "/images/noPhoto.jpg", "Dziewczyna z pociągu" },
                    { 3, true, 0, "Trudno żyć z takim piętnem. Nawet jeśli zmienisz nazwisko, i tak żyjesz w ciągłym lęku, że ktoś rzuci ci te słowa w twarz. Kathryn miała pięć lat, kiedy jej ukochany tata zabił jej rówieśniczkę i najlepszą przyjaciółkę, Elsie. Teraz jest trzydziestoletnią kobietą i nadal sobie z tym nie poradziła.", "/images/3.jpg", "Córka mordercy" },
                    { 4, true, -5, "Mark Watney kilka dni temu był jednym z pierwszych ludzi, którzy stanęli na Marsie. Teraz jest pewien, że będzie pierwszym, który tam umrze! Straszliwa burza piaskowa sprawia, że marsjańska ekspedycja, w której skład wchodzi Mark Watney, musi ratować się ucieczką z Czerwonej Planety.", "/images/4.jpg", "Marsjanin" },
                    { 5, true, 12, "Alaric Adlay jest znanym na całym świecie pisarzem fantastyki. Sława i pasja nie pozwoliły mu jednak odnaleźć szczęścia i spełnienia życiowego. Kiedy był już pewien, że jego życie utknęło w martwym punkcie, były przełożony złożył mu ryzykowną ofertę.", "/images/5.jpg", "Czarne pióro" },
                    { 6, true, 3, "Planeta Ziemia. 500 000 lat w przyszłość. Ludzkość wymarła tysiące lat temu. Dwoje naukowców, Robert i jego żona June, pozostawali na orbicie Ziemi, do czasu kiedy ta znów będzie nadawać się do zamieszkania.", "/images/6.jpg", "Człowiek" }
                });

            migrationBuilder.InsertData(
                table: "Ceny",
                columns: new[] { "Id", "CzyPromocja", "DataDo", "DataOd", "KsiazkaId", "Wartosc" },
                values: new object[,]
                {
                    { 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6.99f },
                    { 7, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6.99f },
                    { 2, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 12.42f },
                    { 6, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 60.97f },
                    { 3, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 27.95f },
                    { 4, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 26.23f },
                    { 5, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 15.6f }
                });

            migrationBuilder.InsertData(
                table: "KsiazkaAutor",
                columns: new[] { "AutorId", "KsiazkaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 6 },
                    { 5, 6 },
                    { 2, 2 },
                    { 1, 3 },
                    { 4, 5 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "KsiazkaKategoria",
                columns: new[] { "KategoriaId", "KsiazkaId" },
                values: new object[,]
                {
                    { 3, 5 },
                    { 1, 5 },
                    { 4, 3 },
                    { 1, 6 },
                    { 2, 3 },
                    { 4, 2 },
                    { 2, 2 },
                    { 4, 1 },
                    { 2, 1 },
                    { 3, 4 },
                    { 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ceny_KsiazkaId",
                table: "Ceny",
                column: "KsiazkaId");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaAutor_AutorId",
                table: "KsiazkaAutor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaKategoria_KategoriaId",
                table: "KsiazkaKategoria",
                column: "KategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ceny");

            migrationBuilder.DropTable(
                name: "KsiazkaAutor");

            migrationBuilder.DropTable(
                name: "KsiazkaKategoria");

            migrationBuilder.DropTable(
                name: "Autorzy");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Ksiazki");
        }
    }
}
