import os
from PIL import Image
import numpy as np

def load_and_preprocess_images(image_dir, target_size=(64, 64)):
    images = []
    labels = []
    class_names = sorted(os.listdir(image_dir))

    for label, class_name in enumerate(class_names):
        class_dir = os.path.join(image_dir, class_name)
        if not os.path.isdir(class_dir):
            continue
        for filename in os.listdir(class_dir):
            if filename.lower().endswith(('.png', '.jpg', '.jpeg')):
                img_path = os.path.join(class_dir, filename)
                img = Image.open(img_path).convert('RGB')
                img = img.resize(target_size)
                img_array = np.array(img) / 255.0
                images.append(img_array)
                labels.append(label)

    images = np.array(images)
    labels = np.array(labels)
    return images, labels, class_names

if __name__ == "__main__":
    # Example usage
    image_dir = 'path_to_dataset'
    images, labels, class_names = load_and_preprocess_images(image_dir)
    print(f"Loaded {len(images)} images from {len(class_names)} classes.")
