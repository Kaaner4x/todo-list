# Interactive Console To-Do List Application 📓

A clean, modern, and robust C# console application to manage your daily tasks. Designed with a clear separation of concerns (Entities, Services, UI, Console Helpers) and built-in input validation.

## 📖 What is this To-Do List Application?

This application is a command-line tool that lets you manage a personal to-do list. Each task (note) consists of:
- A unique auto-incrementing **Note ID**.
- A **Title** and **Content** description.
- A **Created Date** timestamp.
- A completion **Status** (Done / Not Done).

It features a clean text-based terminal user interface with custom color highlights (e.g., Green for Done, Red for Not Done, Cyan for headers) and input validation to keep the app crash-free.

## 🎯 Key Features

1. **View All Notes**: Displays a formatted list of all notes, color-coded by their completion status.
2. **Review a Note**: Retrieve and read the full content of a specific note by entering its ID.
3. **Add a Note**: Prompt-based note creation with title, content, and auto-generated sequential IDs.
4. **Update a Note**: An interactive sub-menu allowing you to update a note's title, description, or toggle its status.
5. **Delete a Note**: Safe deletion flow that displays the target note's details and requires user confirmation (`y/n`) before removing.
6. **Robust Input Utility**: Type-safe prompts, EOF prevention for redirected streams, and safety checks on terminal clearing operations.

## 🚀 How to Run

Follow these steps to compile and run the application on your local machine:

### Prerequisites
- [.NET SDK 10.0](https://dotnet.microsoft.com/download) or higher must be installed on your system.

### Steps
1. **Clone the repository** (or download the source code):
   ```bash
   git clone https://github.com/Kaaner4x/todo-list.git
   ```
2. **Navigate to the project directory**:
   ```bash
   cd ToDoList
   ```
3. **Build the application**:
   ```bash
   dotnet build
   ```
4. **Run the application**:
   ```bash
   dotnet run
   ```
5. **Usage**:
   - The program will display the Main Menu. Enter the number corresponding to the action you want to perform:
     ```plaintext
      📓 Main Menu
                                              
      1. View all notes
      2. Review a note
      3. Add a note
      4. Update a note
      5. Delete a note
      6. Clear the console
      7. Exit

      👉 Please enter an action you want to perform: 1
     ```

## 📄 License

This project is licensed under the [MIT License](LICENSE.txt). See the `LICENSE.txt` file for details.
