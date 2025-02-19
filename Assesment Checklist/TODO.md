**Github Pull Request Workflow**
- [ ] Fork the repository
- [ ] Create a development branch
- [ ] Add functionality by developing your code locally, then committing the changes
- [ ] 'Push' or 'Publish' the changes to your Github repository
- [ ] Create a 'pull' request
- [ ] Invite two other students to review the request
- [ ] Once you've received the reviews, make any changes and merge the modified code
- [ ] Make two reviews
- [ ] Receive two reviews
- [ ] Complete the self assessment checklist

**Self Assessment Checklist**
- [ ] Have the requirements been met?
- [ ] Is the code formatted using the style guidelines correctly?
- [ ] Is the code easy to read?
- [ ] Are different errors handled correctly?

**Coding Task Guidelines**
- Text-based adventure game
- Players navigate through rooms in a dungeon, collect items, battle creatures, ultimately try to reach a treasure or exit.

    **Classes:**
- Game: Handles the game flow and initialises the player and one simple room
- Player: Tracks the player's name and a single attribute, such as health or a basic inventory (single item)
- Room: Represents a single room in the game with a description and possibly an item

    **Encapsulation and Abstraction**
- Use private fields and provide get/set methods where necessary (eg player health or the room description)

    **Methods and Constructors**
- Create constructors for the player and room classes to initialise their attributes
- Implement basic methods:
  - Player.PickUpItem()
  - Room.GetDescription()

  **Basic Game Interaction**
- The player starts in a single room and can:
  - View the room's description
  - Display their current status (eg. Inventory and health)

  **Error Checking**
- Add simple error checking, such as preventing the player from entering a room that does not exist.