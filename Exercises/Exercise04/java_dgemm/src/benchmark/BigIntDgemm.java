package benchmark;

import java.math.BigInteger;

public class BigIntDgemm implements IDgemm{
    private BigInteger alpha;
    private BigInteger beta;
    private BigInteger[][] matrixA;
    private BigInteger[][] matrixB;
    private BigInteger[][] matrixC;
    Reader reader;

    public BigIntDgemm(Reader reader){
        this.reader = reader;
        convertValues();
    }
    @Override
    public void calculateDgemm(){
        BigInteger[][] result = addMatrices(multiplyMatrixByMatrix(multiplyScalarByMatrix(alpha, matrixA), matrixB),
                multiplyScalarByMatrix(beta, matrixC));
    }
    @Override
    public String[] getAnswer(){
        return convertMatrixToString(matrixC);
    }

    public BigInteger[][] multiplyMatrixByMatrix(BigInteger[][] firstMat, BigInteger[][] secondMat){
        BigInteger[][] resultMatrix = new BigInteger[firstMat.length][secondMat[0].length];

        for (int m = 0; m < firstMat.length; m++){
            for (int n = 0; n < secondMat[0].length; n++){
                for (int k = 0; k < secondMat.length; k++){
                    if (resultMatrix[m][n] == null){
                        resultMatrix[m][n] = firstMat[m][k].multiply(secondMat[k][n]);
                    } else {
                        resultMatrix[m][n] = resultMatrix[m][n].add(firstMat[m][k].multiply(secondMat[k][n]));
                    }

                }
            }
        }
        return resultMatrix;
    }

    public BigInteger[][] multiplyScalarByMatrix(BigInteger scal, BigInteger[][] mat){
        for (int m = 0; m < mat.length; m++){
            for (int n = 0; n < mat[0].length; n++){
                mat[m][n] = mat[m][n].multiply(scal);
            }
        }
        return mat;
    }

    public BigInteger[][] addMatrices(BigInteger[][] firstMat, BigInteger[][] secondMat){
        for (int m = 0; m < firstMat.length; m++){
            for (int n = 0; n < secondMat[0].length; n++){
                firstMat[m][n] = firstMat[m][n].add(secondMat[m][n]);
            }
        }
        return firstMat;
    }

    public void convertValues(){
        try {
            int size = reader.getMatrixSize();
            matrixA = new BigInteger[size][size];
            matrixB = new BigInteger[size][size];
            matrixC = new BigInteger[size][size];

            alpha = new BigInteger(reader.getAlpha());
            beta = new BigInteger(reader.getBeta());
            matrixA = convertMatrixToBigInt(reader.getMatrixA());
            matrixB = convertMatrixToBigInt(reader.getMatrixB());
            matrixC = convertMatrixToBigInt(reader.getMatrixC());
        } catch (NumberFormatException e) {
            System.err.println("Error: " + e.getMessage());
        }

    }

    public BigInteger[][] convertMatrixToBigInt(String[][] strMatrix){
        BigInteger[][] matrix = new BigInteger[strMatrix.length][strMatrix.length];
        try {
            for (int i = 0; i < strMatrix.length; i++){
                for (int j = 0; j < strMatrix.length; j++){
                    matrix[i][j] = new BigInteger(strMatrix[i][j]);
                }
            }
        } catch (NumberFormatException e) {
            System.err.println("Error: " + e.getMessage());
        }
        return matrix;
    }

    public String[] convertMatrixToString(BigInteger[][] matrix){
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
