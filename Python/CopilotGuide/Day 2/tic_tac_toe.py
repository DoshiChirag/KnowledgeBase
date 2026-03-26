"""
Terminal-based Tic Tac Toe Game
Two players can play against each other using the terminal.
"""


class TicTacToe:
    def __init__(self):
        """Initialize the game board and game state."""
        self.board = [' ' for _ in range(9)]  # 3x3 board represented as list
        self.current_player = 'X'  # X starts first
        self.game_over = False
        self.winner = None

    def print_board(self):
        """Display the current board state."""
        print("\n")
        print("     |     |     ")
        print(f"  {self.board[0]}  |  {self.board[1]}  |  {self.board[2]}  ")
        print("_____|_____|_____")
        print("     |     |     ")
        print(f"  {self.board[3]}  |  {self.board[4]}  |  {self.board[5]}  ")
        print("_____|_____|_____")
        print("     |     |     ")
        print(f"  {self.board[6]}  |  {self.board[7]}  |  {self.board[8]}  ")
        print("     |     |     ")
        print("\n")

    def print_board_positions(self):
        """Display the board with position numbers for reference."""
        print("\nPosition reference:")
        print("     |     |     ")
        print("  1  |  2  |  3  ")
        print("_____|_____|_____")
        print("     |     |     ")
        print("  4  |  5  |  6  ")
        print("_____|_____|_____")
        print("     |     |     ")
        print("  7  |  8  |  9  ")
        print("     |     |     ")
        print()

    def is_board_full(self):
        """Check if the board is full (draw condition)."""
        return ' ' not in self.board

    def check_winner(self, player):
        """
        Check if the given player has won.
        
        Args:
            player: 'X' or 'O'
            
        Returns:
            True if player has won, False otherwise
        """
        # All possible winning combinations
        winning_combos = [
            [0, 1, 2],  # Top row
            [3, 4, 5],  # Middle row
            [6, 7, 8],  # Bottom row
            [0, 3, 6],  # Left column
            [1, 4, 7],  # Middle column
            [2, 5, 8],  # Right column
            [0, 4, 8],  # Diagonal
            [2, 4, 6],  # Anti-diagonal
        ]

        for combo in winning_combos:
            if all(self.board[i] == player for i in combo):
                return True
        return False

    def make_move(self, position):
        """
        Place a player's mark on the board.
        
        Args:
            position: Position number (1-9)
            
        Returns:
            True if move is valid, False otherwise
        """
        if position < 1 or position > 9:
            print("Invalid position! Please enter a number between 1 and 9.")
            return False

        index = position - 1
        if self.board[index] != ' ':
            print("That position is already occupied! Try again.")
            return False

        self.board[index] = self.current_player
        return True

    def switch_player(self):
        """Switch the current player from X to O or vice versa."""
        self.current_player = 'O' if self.current_player == 'X' else 'X'

    def get_player_move(self):
        """
        Get valid input from the current player.
        
        Returns:
            Valid position number (1-9)
        """
        while True:
            try:
                position = int(input(f"Player {self.current_player}, enter position (1-9): "))
                if self.make_move(position):
                    return position
            except ValueError:
                print("Invalid input! Please enter a number between 1 and 9.")

    def play_turn(self):
        """Execute one turn of the game."""
        self.print_board()
        self.get_player_move()

        if self.check_winner(self.current_player):
            self.game_over = True
            self.winner = self.current_player
        elif self.is_board_full():
            self.game_over = True
            self.winner = None  # Draw
        else:
            self.switch_player()

    def play_game(self):
        """Main game loop."""
        print("=" * 50)
        print("Welcome to Tic Tac Toe!")
        print("=" * 50)
        print("\nPlayer X vs Player O")
        print("Players take turns entering a position (1-9)")
        self.print_board_positions()

        while not self.game_over:
            self.play_turn()

        # Game Over
        self.print_board()
        if self.winner:
            print("=" * 50)
            print(f"🎉 Player {self.winner} WINS! 🎉")
            print("=" * 50)
        else:
            print("=" * 50)
            print("It's a DRAW! Well played both players!")
            print("=" * 50)


def main():
    """Main function to run the game."""
    while True:
        game = TicTacToe()
        game.play_game()

        # Ask if players want to play again
        while True:
            play_again = input("\nDo you want to play again? (yes/no): ").strip().lower()
            if play_again in ['yes', 'y']:
                break
            elif play_again in ['no', 'n']:
                print("Thanks for playing! Goodbye!")
                return
            else:
                print("Please enter 'yes' or 'no'.")


if __name__ == "__main__":
    main()
