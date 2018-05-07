git submodule deinit -f -- "LevelEditor/Engine"
RD /S /Q ".git/modules/Engine"
git rm -f "LevelEditor/Engine"
git submodule add --name "Engine" https://github.com/SilverbackSoPra/Engine.git "LevelEditor/Engine"
git submodule init
git submodule deinit -f -- "LevelEditor/Content/Shader"
RD /S /Q ".git/modules/Shader"
git rm -f "LevelEditor/Content/Shader"
git submodule add --name "Shader" https://github.com/SilverbackSoPra/Shader.git "LevelEditor/Content/Shader"
git submodule init