# Office Tools #

This tools are useful to read or create office documents. There are two supported document types:

  * Word
  * Excel

**Please note that you need an Office Installation to run this code.**

## Word ##

The basic is the object WordDocument. Here you can create an empty or load a existing document. The next level are the sections. A section represent a page. In it there are paragraphs with text and formatting. And that is it!

_Example for Creation_
```
using (WordDocument doc = WordDocument.CreateDocument())
            {
                WordSection section = doc.GetAllSections()[0];

                WordParagraph paragraph = section.CreateParagraph();
                paragraph.Text = "Hello World";

                WordFormatter formatter = paragraph.Formatter;
                formatter.Background = Color.Red;
                formatter.Foreground = Color.Yellow;
                formatter.Font = new Font("Courier New", 12, FontStyle.Underline | FontStyle.Bold);

                doc.Save(file);
            }
```

**An empty document contains always one section (first page)!**

_Example for Loading_
```
WordDocument doc = null;

            using (MemoryStream ms = new MemoryStream(WORD.ToByteArrayFromBase64String()))
            {
                doc = WordDocument.OpenDocument(ms);
            }
```

## Excel ##

The basic object is ExcelDocument. The next level is the Worksheet, taht represent a single table in the Excel document. In it you can select the cells and format it. That is it!

_Example for Creation_
```
using (ExcelDocument doc = ExcelDocument.CreateDocument())
            {
                ExcelWorksheet worksheet = doc.CreateWorksheet("Test");

                ExcelCell cell = worksheet.GetCellAt(new ExcelCellName(ColumnLetter.CreateSingleColumnLetter(Letter.A), 1));
                cell.Text = "Hello World";

                ExcelFormatter formatter = worksheet.GetFormatterAt(
                    new ExcelCellName(ColumnLetter.CreateSingleColumnLetter(Letter.A), 1),
                    new ExcelCellName(ColumnLetter.CreateSingleColumnLetter(Letter.C), 3));
                formatter.Background = Color.Red;
                formatter.Foreground = Color.Yellow;
                formatter.BorderColor = Color.Blue;
                formatter.Font = new Font("Courier New", 12, FontStyle.Underline | FontStyle.Bold);
                formatter.Merge();
                formatter.ColumnWidth = 100;
                formatter.RowHeight = 100;

                doc.Save(file);
            }
```

_Example for Loading_
```
ExcelDocument doc = null;

            using (MemoryStream ms = new MemoryStream(EXCEL.ToByteArrayFromBase64String()))
            {
                doc = ExcelDocument.OpenDocument(ms);
                Assert.AreEqual(4, doc.GetAllWorksheets().Length);
            }
```

## Important ##
Please **do not forget call _dispose_ method** on document object. **Otherwise** a Word or Excel **Instance stays open**!