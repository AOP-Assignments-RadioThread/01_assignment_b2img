# How to Use

This application provides two tabs for working with image files stored as text files:

- **b2img.txt Tab**  
  - Supports **.b2img.txt** files, which should work exactly as shown in the provided example.  
  - Use the *Import* button to load a file from your system.  

- **b16img.txt Tab**  
  - Supports **.b16img.txt** files, but these must follow a specific format since we didn't have time to modify the parser.  
  - The **first two lines** must define the **width** and **height** of the image.  
  - The following lines should contain pixel colors represented as **integers from 0 to 15**, separated by spaces.  
  - Each row must start on a **new line**.

### Example b16img.txt File

```
3 3
12 13 14
1 2 4
5 4 11
```

### Features
- Press the *Import* button to **select and load a text file**.  
- Use the **color palette** to choose a color.  
- Click on a square to **change its color** to the selected one.
- Click on the save button to save the changes to the selected file.  

You can use the example files provided in the repository to test the application.

