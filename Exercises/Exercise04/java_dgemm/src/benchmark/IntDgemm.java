package benchmark;

public class IntDgemm implements IDgemm{
    private int alpha;
    private int beta;
    private int[][] matrixA;
    private int[][] matrixB;
    private int[][] matrixC;
    Reader reader;

    public IntDgemm(Reader reader){
        this.reader = reader;
        convertValues();
    }

    @Override
    public void calculateDgemm(){
        int[][] result = addMatrices(multiplyMatrixByMatrix(multiplyScalarByMatrix(alpha, matrixA), matrixB),
                multiplyScalarByMatrix(beta, matrixC));
    }
    @Override
    public String[] getAnswer(){
        return convertMatrixToString(matrixC);
    }

    public int[][] multiplyMatrixByMatrix(int[][] firstMat, int[][] secondMat){
        int[][] resultMatrix = new int[reader.getMatrixSize()][reader.getMatrixSize()];

        for (int m = 0; m < reader.getMatrixSize(); m++){
            for (int n = 0; n < reader.getMatrixSize(); n++){
                for (int k = 0; k < reader.getMatrixSize(); k++){
                    resultMatrix[m][n] += firstMat[m][k] * secondMat[k][n];
                }
            }
        }
        return resultMatrix;
    }

    public int[][] multiplyScalarByMatrix(int scal, int[][] mat){
        for (int m = 0; m < reader.getMatrixSize(); m++){
            for (int n = 0; n < reader.getMatrixSize(); n++){
                mat[m][n] = mat[m][n] * scal;
            }
        }
        return mat;
    }

    public int[][] addMatrices(int[][] firstMat, int[][] secondMat){
        for (int m = 0; m < reader.getMatrixSize(); m++){
            for (int n = 0; n < reader.getMatrixSize(); n++){
                firstMat[m][n] += secondMat[m][n];
            }
        }
        return firstMat;
    }

    public void convertValues(){
        try {
            int size = reader.getMatrixSize();
            matrixA = new int[size][size];
            matrixB = new int[size][size];
            matrixC = new int[size][size];

            alpha = Integer.parseInt(reader.getAlpha());
            beta = Integer.parseInt(reader.getBeta());
            matrixA = convertMatrixToInt(reader.getMatrixA());
            matrixB = convertMatrixToInt(reader.getMatrixB());
            matrixC = convertMatrixToInt(reader.getMatrixC());
        } catch (NumberFormatException e) {
            System.err.println("Error: " + e.getMessage());
        }
    }

    public int[][] convertMatrixToInt(String[][] strMatrix){
        int[][] matrix = new int[strMatrix.length][strMatrix.length];
        try {
            for (int i = 0; i < strMatrix.length; i++){
                for (int j = 0; j < strMatrix.length; j++){
                    matrix[i][j] = Integer.parseInt(strMatrix[i][j]);
                }
            }
        } catch (NumberFormatException e) {
            System.err.println("Error: " + e.getMessage());
        }
        return matrix;
    }

    public String[] convertMatrixToString(int[][] matrix){
        String[] result = new String[matrix.length];
        for (int i = 0; i < matrix.length; i++){
            StringBuilder string = new StringBuilder();
            for (int j = 0; j < matrix.length; j++){
                string.append(matrix[i][j] + " ");
            }
            result[i] = string.toString().trim();
        }
        return result;
    }
}