# readme

## SDLC

software development lifecycle

the process of creating a product through requirements, design, development, testing and package.

- waterfall model (copied from engineering)
  requirements (6-12mos) --> design (6-12mos) --> dev (12-18mos) --> test (3-6mos) --> pack (1-3mos)

  - mission critical systems
  - long running systems
  - lots of resources
  - big teams
  - 60-70% efficiency

- big bang model
  requirements --> [design, dev, test] --> pack

  - prototype projects
  - proof of concepts
  - small teams
  - <=50% efficiency

- iteration/spiral model
  [req --> dev --> test --> pack] per each requirement with feedback loop

  - small/medium projects
  - midsize teams
  - <=70% efficiency

- v-model
  [validation - verification]

- agile model
  - CMMI = capability maturity model integration (5-6 levels)
  - Kanban = column state (backlog, todo, doing, done), swimlane (components)
  - Scrum = backlog, sprint, capacity, velocity, user story, epic

## Agile/Scrum

- backlog = collection of stories/reqs to achieve product definition
- epic = goal towards a specific feature set, strict set of stories
- story = business req [description, acceptance criteria, stakeholders]
- sprint = timeline for story completion, [2-4 weeks]
  - sprint planning, backlog grooming
  - sprint review/retrospective
  - code review
  - standup daily [what did you do, what are you doing, any blocker/impediment]
- capacity = number of workable hours [20-25 hours]
- velocity = degree of effort (unitless) [linear, binary, fibonacci series][ex. 1,2,3,5,8]

## Docker

- dockerfile
  a set of instructions to generate an image (configuration)
- image
  a representational unit of application binary and dependencies, definition of the application
- container
  a running instance of an image
- registry
  a collection of image repository
