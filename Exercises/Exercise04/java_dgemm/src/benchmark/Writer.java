package benchmark;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class Writer {
    public void write(long time, int matrix_size, String value_type){
        try (BufferedWriter writer = new BufferedWriter(new FileWriter("..\\Results\\results.csv", true))){
            StringBuilder result = new StringBuilder();
            result.append("java");
            result.append(",");
            result.append(value_type);
            result.append(",");
            result.append(matrix_size);
            result.append(",");
            result.append(String.valueOf(time));

            writer.write(result.toString() + "\n");
        } catch (IOException e){
            System.err.println("Error: " + e.getMessage());
        }
    }
}
