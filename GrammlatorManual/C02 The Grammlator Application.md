# 2. The Grammlator Application
## 2.1 Install and Run Grammlator
Grammlator is written in C# using Visual Studio. The source files and binaries are available as a GitHub project.

The grammlator project is published in https://github.com/Rudolf-G/grammlator20 . This project can be downloaded and executed in Visual Studio.

The binaries are stored in https://github.com/Rudolf-G/grammlator20/tree/master/published as a zip-file. This zip-file can be downloaded (click the "download"-button) and unpacked in a directory. Then the contained exe-file can be started. It requires the other unpacked files in the same directory.

## 2.2 The Grammlator User Interface

### 2.2.a Overview

Grammlator shows up with a clearly structured user interface.
<img src="C:\Users\Rolf\Documents\VisualStudioMeineProjekte\GrammlatorDocumentation\GrammlatorManual\Grammlator-Screenshot-no-source.jpg"  /> 

The **title** displays the name of the actual source file (or "grammlator -no file-").

Below the title is the **menu  `File Translate Compare Help` **.

Each of the **tabs `Source | Log | Symbols | Conflicts | States 1 | States 2 | Result | Info`** contains a text box. 

In  the **bottom area** grammlator will display messages which reference the source with line and column numbers. Clicking or double clicking one of the messages will scroll the source text so that the respective line is visible and a marker starts at or near the column. The marker will become visible immediately after a double click or as soon as the mouse is positioned over the textbox.

### 2.2.b The File Menu

After starting grammlator you can type your source code into the **source textbox**. Or paste it from the clipboard. 

Or you can click **File** in the "File-Menu" and

- **`Load source file ...` **in the submenu. This will copy the source text from the file and clear all previous results. The file will not be blocked and the  name of the file will be used as default filename and displayed in the title of the main window. 
- **`Clear source tab !`** will clear the source textbox and all results so that you can start from scratch. It has no effect on a file and will clear the default file name.

As soon as the source textbox contains five lines or more, 

- **`Save source ...`** will be enabled. This will open a file dialog preset with the source filename (if the source previously has been loaded from or saved to a file). If the user stores the source with a new filename then grammlator will display the new filename in the title of the main window and will use it as new default filename.

The submenus  **Save result ...** and **Save result to source ..** will be active as soon as the result of an error free translation is available . 

- **`Save result ...`** opens the file dialog and presets the filename with the default filename with an appended "-generated" (if the source has been loaded from a file).

- **`Save result to source ...`** first replaces the contents of the source textbox with the result of the translation an then opens the "Save source" file dialog (see `Save source ..`). Warning: Changes of the source since the last `Translate` will be lost. If there are no such changes, only the "#region grammlator generated" will be changed.

### 2.2.c Source text: Edit, Translate, Save result

The shortest program fragment that grammlator will accept as a source is

```c#
#region grammar
//| *= ;
#endregion grammar
#region grammlator generated
#endregion grammlator generated
```

**Exercise 2.2c:** *Cut and paste this text into the source text box of grammlator and then click **`Translate` / `with standard options`***.

There is only a minimum of edit commands implemented in grammlator (the standard edit possibilities of text boxes). This is sufficient for testing simple examples or to key small adjustments into a source. .

To edit complex applications it is recommended to use a C# development system like Visual Studio, store the file without closing this  system, load the file in grammlator, translate it (see above). If there are errors do modifications again in the C# development system, store the file, then in grammlator click **`Translate` /  `reload source and translate`**. If the translation was successful  **`Save result to source ...`** and continue programming in Visual Studio etc.. To have a break before solving all problems **Save source ...**.

### 2.2.d Log and message area

Even the minimal example of *exercise 2.2.c*  generates messages.  Each time a grammar is translated, the **Log**, **Symbols**, **Conflicts**, **States 1**, **States 2** and **Result** texts and the **message area** are cleared and filled with the results of the new translation. The details are specified later. The small example shows  the principles.

All messages are listed in the **Log**. Some messages are curtailed using "...". These refer to message boxes, which are displayed in the message area. A single click into one of these boxes will show up the source textbox and set the marker to the respective position. The marker will be visible as soon as the cursor is moved over the source text or if the message box is double clicked.

### 2.2.e Help menu and Info tab

Clicking `Help` opens the submenus `Display example` and `Display setting`.

Grammlator is installed together with  a small set of examples, which are contained in a zip-file. Selecting one of the examples displays the example in the Info tab.

A lot of settings control how grammlator generates code. These settings can be changed by assignments at the start of the grammlator region. `Display settings` shows all possible settings in the Info tab. For each setting the first line demonstrates how it can be set to with the initial value. A comment explains the usage.

The TextBox in the Info tab is read only. But text can be marked and copied.

### 2.2.f Compare

After the source has been translated and a result is available in the Result tab, clicking `Compare` and `..ignoring leadiong separators` will bring the source into focus and mark the 1st line which is different. The 1st different line is also marked in the Result test.

Leading and trailing whitespace is ignored in the comparision and even the additional data xxx grammlator adds to the `region grammlator generated xxx`and `endregion grammlator generated xxx`

Because only lines in the this region are changed by translation, `Compare` helps to find differences in the generated code, which may be caused by changing grammlator settings or modifying the grammar. Or even differences caused by using another version of grammlator.







