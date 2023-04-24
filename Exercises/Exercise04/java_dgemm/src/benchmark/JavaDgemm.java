package benchmark;

public class JavaDgemm {
    public static void main(String[] args) {
        Reader reader = new Reader();
        reader.read();
        Factory factory = new Factory();
        IDgemm dgemm = factory.create(reader);
        dgemm.calculateDgemm();
//        Writer writer = new Writer();
//        writer.write(reader.getMatrixCFile(), dgemm.getAnswer());
    }
}