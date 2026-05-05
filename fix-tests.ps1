# Script para corrigir os testes para NUnit 4.x
$files = Get-ChildItem -Path "Voting.Domain.Tests" -Filter "*.cs" -Recurse

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw
    
    # Substituir Assert.AreEqual
    $content = $content -replace 'Assert\.AreEqual\(([^,]+),\s*([^\)]+)\)', 'Assert.That($2, Is.EqualTo($1))'
    
    # Substituir Assert.AreNotEqual
    $content = $content -replace 'Assert\.AreNotEqual\(([^,]+),\s*([^\)]+)\)', 'Assert.That($2, Is.Not.EqualTo($1))'
    
    # Substituir Assert.IsTrue
    $content = $content -replace 'Assert\.IsTrue\(([^\)]+)\)', 'Assert.That($1, Is.True)'
    
    # Substituir Assert.IsFalse
    $content = $content -replace 'Assert\.IsFalse\(([^\)]+)\)', 'Assert.That($1, Is.False)'
    
    # Substituir Assert.IsNotNull
    $content = $content -replace 'Assert\.IsNotNull\(([^\)]+)\)', 'Assert.That($1, Is.Not.Null)'
    
    # Substituir Assert.True
    $content = $content -replace 'Assert\.True\(([^\)]+)\)', 'Assert.That($1, Is.True)'
    
    # Substituir Assert.False
    $content = $content -replace 'Assert\.False\(([^\)]+)\)', 'Assert.That($1, Is.False)'
    
    # Substituir .Valid por .IsValid
    $content = $content -replace '\.Valid\b', '.IsValid'
    
    Set-Content -Path $file.FullName -Value $content -NoNewline
}

Write-Host "Testes atualizados com sucesso!"
