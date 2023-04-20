package benchmark;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class Writer {
    public void write(File file, String[] matrix){
        try (BufferedWriter writer = new BufferedWriter(new FileWriter(file))){
            for (String s : matrix) {
                writer.write(s + "\n");
            }
        } catch (IOException e){
            System.err.println("Error: " + e.getMessage());
        }
    }
}
