**Hi, readers!  Help yourself to this code and tutorial!**

**Unfortunately, at the date I created this sample, I had other priorities, so this is it for the README.md for now.  I plan on writing up a full walkthrough article at some point, in order to explain how to do this process in further detail.  For now, enjoy this repository and I hope you learn something from the code -- it's very well-documented!**

# EmployeeManager sample

![Fig01](Resources/fig01.png)
**Figure 1.** Screenshot of the main window of the application.

Illustrates how to create a .mdf database file in Visual Studio 2019, generate a Entity Framework ORM data model for it, scaffold it with a Repository/Unit of Work pattern, and then write a Windows Forms graphical application in order to allow a non-skilled user to manipulate the data.

Putting all the infrastructure discussed above into place makes coding a Windows Forms app (or any other user-friendly presentation layer) very easy -- it boils down to, essentially, just three calls:

* `InitializeAll()` to bring up the connection to the data source;
* `GetAll()` to fetch all the records from the data source for display; and
* `SaveAll()` to save any changes (creates/updates/deletes) to the data source after the user has manipulated the data in the GUI.

So why yet another data sample, you ask?  Because this one has the added benenfit of teaching the use of the full power of T4 Text Template (`.tt`) files to enable generation of the stuff we don't want to have to write ourselves when tables are generated in the database and ORM -- basically, we create new `.tt` files that scaffold our Repository / Unit of Work layer for us, and also set up databinding.  These files do the heavy lifting and continue to do so as our database grows and changes.