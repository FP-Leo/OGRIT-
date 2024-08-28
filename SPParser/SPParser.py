import os
from datetime import datetime

# Define a simple logging function
def log(message):
    log_file_path = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'log.txt')
    with open(log_file_path, 'a') as log_file:
        log_file.write(f'{datetime.now()} - {message}\n')

# Get the current working directory
current_directory = os.path.dirname(os.path.realpath(__file__))

# File paths using relative paths
unformatted_file_path = os.path.join(current_directory, 'unformatted_sql_query.txt')
formatted_file_path = os.path.join(current_directory, 'formatted_sql_query.txt')

try:
    # Read the unformatted SQL query from the file
    log(f'Reading the unformatted SQL query from {unformatted_file_path}')
    with open(unformatted_file_path, 'r') as file:
        sql_query = file.read()

    # Split the SQL query into lines
    lines = sql_query.strip().splitlines()

    # Add a single quote at the beginning and ' + at the end of each line
    formatted_lines = ["'" + line.strip() + " ' +" for line in lines[:-1]]
    formatted_lines.append("'" + lines[-1].strip() + "'")

    # Join the formatted lines into a single string
    formatted_sql_query = "\n".join(formatted_lines)

    # Save the formatted SQL query to a file
    log(f'Saving the formatted SQL query to {formatted_file_path}')
    with open(formatted_file_path, 'w') as file:
        file.write(formatted_sql_query)

    # Clean the unformatted file by writing an empty string to it
    log(f'Cleaning the unformatted file {unformatted_file_path}')
    with open(unformatted_file_path, 'w') as file:
        file.write("")

except Exception as e:
    log(f'An error occurred: {e}')
