from pyspark.sql import SparkSession

spark = SparkSession.builder.getOrCreate()

# Датафрейм с продуктами
products = spark.createDataFrame([
    (1, "Product A"),
    (2, "Product B"),
    (3, "Product C"),
    (4, "Product D")
], ["product_id", "product_name"])

# Датафрейм с категориями
categories = spark.createDataFrame([
    (1, "Category X"),
    (2, "Category Y"),
    (3, "Category Z")
], ["category_id", "category_name"])

# Датафрейм с соответствиями продуктов и категорий
product_categories = spark.createDataFrame([
    (1, 1),
    (1, 2),
    (2, 1),
    (3, 3)
], ["product_id", "category_id"])

# Присоединение продуктов к соответствующим категориям
joined_df = product_categories.join(products, "product_id", "left") \
    .join(categories, "category_id", "left") \
    .select("product_name", "category_name")

# Результат
joined_df.show(truncate=False)
