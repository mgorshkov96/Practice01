package benchmark;

public class JavaDgemm {
    public static void main(String[] args) {
        Reader reader = new Reader();
        reader.read();
        Factory factory = new Factory();
        IDgemm dgemm = factory.create(reader);

        long startTime = System.currentTimeMillis();
        for(int i = 0; i < 100; i++){
            dgemm.calculateDgemm();
        }
        long endTime = System.currentTimeMillis();

        long result = endTime - startTime;

        Writer writer = new Writer();
        writer.write(result, reader.getMatrixSize(), reader.getValueType());
    }
}