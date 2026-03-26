import socket
import threading

def send_messages(client_socket):
    while True:
        # Send a message to the server
        message = input("Enter message to send (type 'exit' to quit): ")
        if message.lower() == 'exit':
            print("Exiting...")
            client_socket.close()
            break
        client_socket.sendall(message.encode('utf-8'))

def receive_messages(client_socket):
    while True:
        try:
            # Receive response from the server
            response = client_socket.recv(1024).decode('utf-8')
            if not response:
                print("Server closed the connection.")
                client_socket.close()
                break
            print(f"Received from server: {response}")
        except ConnectionError:
            print("Connection error. Exiting receive thread.")
            break

def main():
    # Define server address and port
    server_address = '127.0.0.1'
    server_port = 3000

    # Create a client socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    try:
        # Connect to the server
        client_socket.connect((server_address, server_port))
        print(f"Connected to server at {server_address}:{server_port}")

        # Create threads for sending and receiving messages
        send_thread = threading.Thread(target=send_messages, args=(client_socket,))
        receive_thread = threading.Thread(target=receive_messages, args=(client_socket,))

        # Start the threads
        send_thread.start()
        receive_thread.start()

        # Wait for threads to finish
        send_thread.join()
        receive_thread.join()

    except ConnectionError as e:
        print(f"Connection error: {e}")

    finally:
        # Close the connection
        client_socket.close()
        print("Connection closed.")

if __name__ == "__main__":
    main()
