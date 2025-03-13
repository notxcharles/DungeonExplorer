**Github Pull Request Workflow**
- [x] Fork the repository
- [x] Create a development branch
- [x] Add functionality by developing your code locally, then committing the changes
- [x] 'Push' or 'Publish' the changes to your Github repository
- [x] Create a 'pull' request
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
- [x] Text-based adventure game
- Players navigate through rooms in a dungeon, collect items, battle creatures, ultimately try to reach a treasure or exit.

    **Classes:**
- [x] Game: Handles the game flow and initialises the player and one simple room
- [x] Player: Tracks the player's name and a single attribute, such as health or a basic inventory (single item)
- [x] Room: Represents a single room in the game with a description and possibly an item

    **Encapsulation and Abstraction**
- Use private fields and provide get/set methods where necessary (eg player health or the room description)

    **Methods and Constructors**
- [x] Create constructors for the player and room classes to initialise their attributes
- [x] Implement basic methods:
  - [x] Player.PickUpItem()
  - [x] Room.GetDescription()

  **Basic Game Interaction**
- [x] The player starts in a single room and can:
  - [x] View the room's description
  - [x] Display their current status (eg. Inventory and health)

  **Error Checking**
- Add simple error checking, such as preventing the player from entering a room that does not exist.