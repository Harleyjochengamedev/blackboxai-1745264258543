import tensorflow as tf

def convert_model_to_tflite(saved_model_dir, tflite_model_path):
    # Convert the TensorFlow SavedModel to TensorFlow Lite model
    converter = tf.lite.TFLiteConverter.from_saved_model(saved_model_dir)
    tflite_model = converter.convert()

    # Save the TensorFlow Lite model to file
    with open(tflite_model_path, 'wb') as f:
        f.write(tflite_model)
    print(f"Model converted and saved to {tflite_model_path}")

if __name__ == "__main__":
    saved_model_dir = 'path_to_saved_model'
    tflite_model_path = 'model.tflite'
    convert_model_to_tflite(saved_model_dir, tflite_model_path)
