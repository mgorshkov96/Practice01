package benchmark;

public class DoubleDgemm implements IDgemm{
    private double alpha;
    private double beta;
    private double[][] matrixA;
    private double[][] matrixB;
    private double[][] matrixC;
    Reader reader;

    public DoubleDgemm(Reader reader){
        this.reader = reader;
        convertValues();
    }
    @Override
    public void calculateDgemm(){
        matrixC = addMatrices(multiplyMatrixByMatrix(multiplyScalarByMatrix(alpha, matrixA), matrixB),
                multiplyScalarByMatrix(beta, matrixC));
    }
    @Override
    public String[] getAnswer(){
        return convertMatrixToString(matrixC);
    }

    public double[][] multiplyMatrixByMatrix(double[][] firstMat, double[][] secondMat){
        double[][] resultMatrix = new double[firstMat.length][secondMat[0].length];

        for (int m = 0; m < firstMat.length; m++){
            for (int n = 0; n < secondMat[0].length; n++){
                for (int k = 0; k < secondMat.length; k++){
                    resultMatrix[m][n] += firstMat[m][k] * secondMat[k][n];
                }
            }
        }
        return resultMatrix;
    }

    public double[][] multiplyScalarByMatrix(double scal, double[][] mat){
        for (int m = 0; m < mat.length; m++){
            for (int n = 0; n < mat[0].length; n++){
                mat[m][n] = mat[m][n] * scal;
            }
        }
        return mat;
    }

    public double[][] addMatrices(double[][] firstMat, double[][] secondMat){
        for (int m = 0; m < firstMat.length; m++){
            for (int n = 0; n < secondMat[0].length; n++){
                firstMat[m][n] += secondMat[m][n];
            }
        }
        return firstMat;
    }

    public void convertValues(){
        try {
            int size = reader.getMatrixSize();
            matrixA = new double[size][size];
            matrixB = new double[size][size];
            matrixC = new double[size][size];

            alpha = Double.parseDouble(reader.getAlpha());
            beta = Double.parseDouble(reader.getBeta());
            matrixA = convertMatrixToDouble(reader.getMatrixA());
            matrixB = convertMatrixToDouble(reader.getMatrixB());
            matrixC = convertMatrixToDouble(reader.getMatrixC());
        } catch (NumberFormatException e) {
            System.err.println("Error: " + e.getMessage());
        }

    }

    public double[][] convertMatrixToDouble(String[][] strMatrix){
        double[][] matrix = new double[strMatrix.length][strMatrix.length];
        try {
            for (int i = 0; i < strMatrix.length; i++){
                for (int j = 0; j < strMatrix.length; j++){
                    matrix[i][j] = Double.parseDouble(strMatrix[i][j]);
                }
            }
        } catch (NumberFormatException e) {
            System.err.println("Error: " + e.getMessage());
        }
        return matrix;
    }

    public String[] convertMatrixToString(double[][] matrix){
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
