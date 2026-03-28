graph LR
    subgraph INFRA["Infrastructure"]
        EP["Endpoints\nHTTP API"]
        DB["Database\nEF Core · Commands"]
        RM["ReadModels\nDapper · Queries"]
    end
    subgraph APP["Application"]
        AC["App.Contracts\nCommands / Queries / DTOs"]
        AH["Handlers\nMediatR"]
    end
    subgraph DOM["Domain"]
        DM["Domain\nModels · Factories · Specs"]
        DC["Domain.Contracts\nInterfaces / Enums"]
    end

    LP[["📦 LP.Common (NuGet)"]]

    INFRA -->|depends on| APP
    APP -->|depends on| DOM
    INFRA & APP & DOM -.->|shared| LP