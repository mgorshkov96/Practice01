package benchmark;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class Reader {
    private String valueType;
    private int matrixSize;
    private String alpha;
    private String beta;
    private String[][] matrixA;
    private String[][] matrixB;
    private String[][] matrixC;
    private File matrixCFile;

    public String getValueType(){ return valueType; }
    public int getMatrixSize(){ return matrixSize; }
    public String getAlpha(){ return alpha; }
    public String getBeta(){ return beta; }
    public String[][] getMatrixA(){ return matrixA; }
    public String[][] getMatrixB(){ return matrixB; }
    public String[][] getMatrixC(){ return matrixC; }
    public File getMatrixCFile(){ return matrixCFile; }

    public void read(){
        File valueTypeFile = new File("..\\Data\\value_type.txt");
        File matrixSizeFile = new File("..\\Data\\matrix_size.txt");
        File alphaFile = new File("..\\Data\\alpha.txt");
        File betaFile = new File("..\\Data\\beta.txt");
        File matrixAFile = new File("..\\Data\\matrix_a.txt");
        File matrixBFile = new File("..\\Data\\matrix_b.txt");
        matrixCFile = new File("..\\Data\\matrix_c.txt");

        try (BufferedReader valueTypeReader = new BufferedReader(new FileReader(valueTypeFile))) {
            valueType = valueTypeReader.readLine();
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }

        try (BufferedReader matrixSizeReader = new BufferedReader(new FileReader(matrixSizeFile))) {
            matrixSize = Integer.parseInt(matrixSizeReader.readLine());
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        } catch (NumberFormatException e) {
            System.err.println("Error: " + e.getMessage());
        }

        matrixA = new String[matrixSize][matrixSize];
        matrixB = new String[matrixSize][matrixSize];
        matrixC = new String[matrixSize][matrixSize];

        try (BufferedReader alphaReader = new BufferedReader(new FileReader(alphaFile))) {
            alpha = alphaReader.readLine();
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }

        try (BufferedReader betaReader = new BufferedReader(new FileReader(betaFile))) {
            beta = betaReader.readLine();
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }

        try (BufferedReader matrixAReader = new BufferedReader(new FileReader(matrixAFile))) {
            String input;
            int counter = 0;
            while ((input = matrixAReader.readLine()) != null){
                matrixA[counter] = input.split(" ");
                counter++;
            }
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }

        try (BufferedReader matrixBReader = new BufferedReader(new FileReader(matrixBFile))) {
            String input;
            int counter = 0;
            while ((input = matrixBReader.readLine()) != null){
                matrixB[counter] = input.split(" ");
                counter++;
            }
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }

        try (BufferedReader matrixCReader = new BufferedReader(new FileReader(matrixCFile))) {
            String input;
            int counter = 0;
            while ((input = matrixCReader.readLine()) != null){
                matrixC[counter] = input.split(" ");
                counter++;
            }
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }
    }
}
