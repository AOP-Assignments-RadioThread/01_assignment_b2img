# 01_assignment_b2img
This is the first bonus point homework assignment, covering the introduction lectures to GUI Object Oriented Programming.

# **B2Img Editor**

## **Overview**
This repository contains an application that enables users to **read, modify, and save** `.b2img.txt` files through a graphical interface.

## **Features**
### **Base Features**
- Load a `.b2img.txt` file and parse its contents.
- Display the image as a **grid of pixels**.
- Allow users to **modify pixels** by clicking on them.
- Save the modified file in the `.b2img.txt` format.

### **File Format**
A `.b2img.txt` file consists of:
- **First Line**: Two numbers separated by a space (**height** and **width** of the image).
- **Remaining Lines**: A sequence of `0`s and `1`s representing the pixel values.

#### **Example (`smile.b2img.txt`)**:
```
6 7            
010001000000000
000000000000010
000010111110   
```

---

## **Grading & Bonus Features**
### **Basic Requirements (1 Bonus Point)**
- The application should be easy to set up and use.
- It must support all required base functionalities.

### **Advanced Features (2 Bonus Points)**
To earn two bonus points, implement at least one of the following:
- **New Image Format (`.b16img.txt`)**: Supports color images.
- **Binary File Format (`.b2img`)**: Store image data in binary format instead of text.
- **Import/Export to PNG/BMP**: Convert `.b2img.txt` to/from standard image formats.
- **Multi-File Tabs**: Allow multiple images to be open simultaneously.
- **Image Flipping**: Implement horizontal/vertical flip functionality.

---

## **Project Structure**
```
B2ImgEditor/
│── Models/        # File parsing & image data handling
│── ViewModels/    # MVVM logic (data binding & commands)
│── Views/         # UI components (Avalonia XAML)
│── Resources/     # Icons, themes, additional assets
│── README.md      # This file
│── .gitignore     # Files to be ignored by Git
│── LICENSE        # License information
```

---

## **User Interface**
The application displays an **interactive pixel grid**, allowing users to **edit** and **save** images. Example UI:
```
╭──────────────────╮
│ example.app   ─ X│
├──────────────────┤
│     size:6x7     │
│ ╔══════════════╗ │
│ ║  ██      ██  ║ │
│ ║  ██      ██  ║ │
│ ║              ║ │
│ ║      ██      ║ │
│ ║██          ██║ │
│ ║  ██████████  ║ │
│ ╚══════════════╝ │
│╭────────────────╮│
││out.b2img.txt   ││
│╰────────────────╯│
│ ╭──────╮╭──────╮ │
│ │ load ││ save │ │
│ ╰──────╯╰──────╯ │
╰──────────────────╯
```

---

## **Code Example**

#### **Before Modification**:
```csharp
var image = new int[6,7] {
 {0,1,0,0,0,1,0},
 {0,0,0,0,0,0,0},
 {0,0,0,0,0,0,0},
 {0,0,0,0,0,0,0},
 {1,0,0,0,0,0,1},
 {0,1,1,1,1,1,0}
};
```

#### **After Modification**:
```csharp
var image = new int[6,7] {
 {0,1,0,0,0,1,0},
 {0,1,0,0,0,1,0},
 {0,0,0,0,0,0,0},
 {0,0,0,1,0,0,0},
 {1,0,0,0,0,0,1},
 {0,1,1,1,1,1,0}
};
```

---

## **Setup Instructions**
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/B2ImgEditor.git
   cd B2ImgEditor
   ```
2. Build the project:
   ```sh
   dotnet build
   ```
3. Run the application:
   ```sh
   dotnet run
   ```

---

## **Contribution Guidelines**
- Fork the repository.
- Create a new branch (`feature/your-feature`).
- Make changes and test thoroughly.
- Open a **pull request** for review.

---

## **License**
This project is licensed under the **MIT License**. See `LICENSE` for details.

🚀 *Happy coding!*


