import socket
import threading

# Global list of active client sockets
clients = []
# Lock to synchronize access to `clients
clients_lock = threading.Lock() 

def handle_client(client_socket):
        # Add the new client socket to the global list in a thread-safe way
        with clients_lock:
            clients.append(client_socket)

        try:
            while True:
                request = client_socket.recv(1024)
                if not request:
                    # No data -> client closed the connection
                    break

                try:
                    message = request.decode('utf-8')
                except Exception:
                    message = repr(request)

                print(f"Received: {message}")

                # Forward the message to all connected clients
                with clients_lock:
                    for client in clients:
                        if client != client_socket:  # Avoid sending the message back to the sender
                            try:
                                client.sendall(message.encode('utf-8'))
                            except Exception:
                                # Handle any exceptions during sending
                                pass

                client_socket.send(b"ACK")
        except Exception as e:
            print(f"Error handling client: {e}")
        finally:
            # Remove the client socket from the global list and close it
            with clients_lock:
                try:
                    clients.remove(client_socket)
                except ValueError:
                    # Socket was not in the list (already removed)
                    pass
            try:
                client_socket.close()
            except Exception:
                pass



def main():
        server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        server.bind(("localhost", 3000))
        server.listen(5)
        print("Server listening on port 3000")
        while True:
            client_socket, addr = server.accept()
            print(f"Accepted connection from {addr}")
            client_handler = threading.Thread(target=handle_client, args=(client_socket,))
            client_handler.daemon = True
            client_handler.start()

if __name__ == "__main__":
        main()