import pandas as pd
import matplotlib.pyplot as plt

def visualize_profit(data_frame):
    """
    Visualizes the profit by product using a bar chart.

    The input DataFrame must contain 'Product', 'Sales', and 'Cost' columns.
    """
    # check if the required columns exist in the DataFrame
    if 'Sales' not in data_frame.columns or 'Cost' not in data_frame.columns:
        raise ValueError("DataFrame must contain 'Sales' and 'Cost' columns")
    if 'Product' not in data_frame.columns:
        raise ValueError("DataFrame must contain 'Product' column")
    data_frame['Profit'] = data_frame['Sales'] - data_frame['Cost']
    data_frame.plot(x='Product', y='Profit', kind='bar', legend=False, title='Profit by Product')
    plt.ylabel('Profit')
    plt.show()