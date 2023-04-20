package benchmark;

public class Factory {
    public IDgemm create(Reader reader){
        switch (reader.getValueType()) {
            case "Int": return new IntDgemm(reader);
            case "Double": return new DoubleDgemm(reader);
            case "BigInt": return new BigIntDgemm(reader);
            default: return null;
        }
    }
}
