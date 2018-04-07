git config --global user.name "Fagner Canto"
git config --global user.email "fagnercantosantos@gmail.com"

Existing folder
cd C:\Users\Administrador\projetos
git init
git remote add origin https://gitlab.com/fagnercantosantos/PlataformaCasoTeste.git
git add .
git commit -m "Master init"
git push -u origin master

Existing Git repository
cd existing_repo
git remote rename origin old-origin
git remote add origin https://gitlab.com/fagnercantosantos/PlataformaCasoTeste.git
git push -u origin --all
git push -u origin --tags