# Contributing Guidelines

This document provides guidelines for adding and organizing game design projects in this repository.

## Repository Purpose

This repository is a personal portfolio for game design work from the UW Game Design certificate course. It serves to:
- Document game design concepts and learning
- Showcase playable game prototypes
- Track design iteration and improvement

## Adding a New Project

### 1. Choose the Right Location

**Academic Projects** (`academic-projects/`)
- Conceptual designs and paper prototypes
- Game mechanics analysis
- Design theory explorations
- Academic assignments

**Playable Games** (`playable-games/`)
- Working game prototypes
- Complete playable experiences
- Interactive demos
- Game jam submissions

### 2. Create Project Directory

```bash
# For academic projects
mkdir academic-projects/your-project-name

# For playable games
mkdir playable-games/your-game-name
```

Use descriptive, lowercase names with hyphens (e.g., `puzzle-platformer`, `card-game-design`).

### 3. Document Your Project

1. Copy the project template:
   ```bash
   cp templates/PROJECT_TEMPLATE.md your-project-directory/README.md
   ```

2. Fill out all relevant sections:
   - Overview and concept
   - Gameplay mechanics
   - Design goals
   - Development status
   - Credits and references

### 4. Organize Your Files

Recommended structure for each project:

```
project-name/
├── README.md              # Main project documentation
├── docs/                  # Additional design documents
│   ├── mechanics.md
│   ├── level-design.md
│   └── narrative.md
├── assets/                # Visual and audio assets
│   ├── images/
│   ├── audio/
│   └── mockups/
├── src/                   # Source code (for playable games)
└── builds/                # Playable builds (gitignored)
```

### 5. Update the Catalog

Add your project to `PROJECTS.md`:

**For Academic Projects:**
```markdown
| Project Name | Type | Status | Description |
|--------------|------|--------|-------------|
| Your Project | Concept | 🎯 | Brief description |
```

**For Playable Games:**
```markdown
| Game Name | Genre | Platform | Status | Description |
|-----------|-------|----------|--------|-------------|
| Your Game | Puzzle | Web | ✅ | Brief description |
```

## Project Documentation Best Practices

### Required Elements
- Clear project overview
- Core gameplay mechanics
- Design goals and player experience
- Current development status
- Credits and acknowledgments

### Optional But Recommended
- Screenshots or mockups
- Gameplay videos or GIFs
- Playtesting feedback
- Design iteration notes
- Post-mortem analysis

## File Organization Tips

### Naming Conventions
- Use lowercase with hyphens for directories: `tower-defense-game`
- Use descriptive names for files: `movement-mechanics.md`, not `doc1.md`
- Include version numbers for builds: `game-v1.0.zip`

### Asset Management
- Keep original source files (PSD, AI, etc.)
- Export optimized versions for builds
- Include attribution for external assets
- Document asset licenses in README

### Code Organization (for playable games)
- Follow the language/engine conventions
- Include comments for complex systems
- Document dependencies in README
- Provide build/run instructions

## Commit Messages

Use clear, descriptive commit messages:

```
✅ Good:
- "Add puzzle mechanics documentation"
- "Implement player movement system"
- "Update level 3 based on playtesting feedback"

❌ Avoid:
- "update"
- "fixes"
- "stuff"
```

## Design Documentation

### What to Include
1. **Inspiration**: What games or ideas influenced this project?
2. **Core Loop**: What does the player do repeatedly?
3. **Unique Elements**: What makes this design different?
4. **Challenges Faced**: What problems did you solve?
5. **Lessons Learned**: What would you do differently?

### Design Diagrams
- Flow charts for game loops
- State diagrams for game systems
- Wireframes for UI/UX
- Level layouts and maps

## Quality Standards

### Academic Projects
- Clear explanation of design concepts
- Well-reasoned design decisions
- References to design theory or research
- Critical analysis of mechanics

### Playable Games
- Working build or live demo
- Clear play instructions
- Bug-free core experience
- Documented known issues

## Version Control

### What to Commit
- Source code
- Design documents
- Small images and assets (<1MB)
- Configuration files

### What NOT to Commit
- Large binary files (use Git LFS if needed)
- Build artifacts (executables, compiled code)
- Temporary files
- Sensitive information or API keys
- Third-party libraries (use package managers)

Check `.gitignore` before committing!

## Getting Help

If you're unsure about where or how to add something:
1. Look at existing projects for examples
2. Review the project template
3. Open an issue for discussion

## Repository Maintenance

### Regular Updates
- Keep project statuses current
- Archive completed projects
- Update catalog with new additions
- Remove unused files

### Annual Review
- Evaluate project organization
- Update templates based on needs
- Consolidate or reorganize as needed
- Add year-end summary

---

*These guidelines help maintain a clean, professional portfolio that showcases game design work effectively.*
