@echo off

git config core.hooksPath scripts/git-hooks
echo git hooks path set to scripts/git-hooks

git update-index --skip-worktree ../src/nuget.config
echo skip-worktree set on src/nuget.config

echo:
pause