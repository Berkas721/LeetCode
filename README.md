TODO:
1) сделать везде using Dto = ...
2) сделать роли
3) сделать обработчик ошибок
4) много query запросов


Необходимо сделать 2 роли: создатели задач и обычные пользователи.

Создатели задач могут: создавать, изменять и тестировать Problem, ImplementedProblems, TestCases пока Problem находится в состоянии черновика.
Создатели специальным запросом потверждают что закончили заполнение задачи и если данные корректны (каждый workingSolution проходит тестирование с testcases) задача открывается.

Обычный пользователь может создавать новые Solutions. 
Тестировать явно он может только отдельно прописанные. 
Когда он уверен, что все норм, он потверждает сдачу задачи и происходит полная проверка, после которой задача принимает статус принята / не принята и больше не может изменяться.

<mxfile host="Electron" modified="2024-11-15T15:11:11.747Z" agent="Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) draw.io/23.0.2 Chrome/120.0.6099.109 Electron/28.1.0 Safari/537.36" etag="i6wGhZp1GWep2rcrmMoK" version="23.0.2" type="device">
  <diagram id="R2lEEEUBdFMjLlhIrx00" name="Page-1">
    <mxGraphModel dx="2206" dy="2398" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="850" pageHeight="1100" math="0" shadow="0" extFonts="Permanent Marker^https://fonts.googleapis.com/css?family=Permanent+Marker">
      <root>
        <mxCell id="0" />
        <mxCell id="1" parent="0" />
        <mxCell id="uBWajqLBtvn8ZttVkuIT-1" value="Problem" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;fillColor=#fff2cc;strokeColor=#d6b656;" parent="1" vertex="1">
          <mxGeometry x="190" y="-720" width="160" height="236" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-2" value="id PK" style="text;strokeColor=#d6b656;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-1" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-3" value="name AK" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-1" vertex="1">
          <mxGeometry y="56" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-45" value="description" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-1" vertex="1">
          <mxGeometry y="86" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-5" value="difficulty" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-1" vertex="1">
          <mxGeometry y="116" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-11" value="createInfo ActionInfo" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-1" vertex="1">
          <mxGeometry y="146" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="_Fd129SVDlIRFtZf2qv7-16" value="status" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-1" vertex="1">
          <mxGeometry y="176" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="aDxvkXDtERVIUQvnmX8f-3" value="&lt;i&gt;&lt;strike&gt;testcase_json_schema&lt;/strike&gt;&lt;/i&gt;" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;dashed=1;" parent="uBWajqLBtvn8ZttVkuIT-1" vertex="1">
          <mxGeometry y="206" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-12" value="Problem solution" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;fillColor=#d5e8d4;strokeColor=#82b366;" parent="1" vertex="1">
          <mxGeometry x="705" y="-410" width="188.75" height="176" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-13" value="id PK" style="text;strokeColor=#82b366;fillColor=#d5e8d4;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-12" vertex="1">
          <mxGeometry y="26" width="188.75" height="30" as="geometry" />
        </mxCell>
        <mxCell id="_Fd129SVDlIRFtZf2qv7-1" value="user_id&amp;nbsp;FK" style="text;strokeColor=none;fillColor=#d5e8d4;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-12" vertex="1">
          <mxGeometry y="56" width="188.75" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-94" value="implemented_problem_id FK" style="text;strokeColor=none;fillColor=#d5e8d4;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-12" vertex="1">
          <mxGeometry y="86" width="188.75" height="30" as="geometry" />
        </mxCell>
        <mxCell id="uBWajqLBtvn8ZttVkuIT-27" value="code" style="text;strokeColor=none;fillColor=#d5e8d4;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-12" vertex="1">
          <mxGeometry y="116" width="188.75" height="30" as="geometry" />
        </mxCell>
        <mxCell id="_Fd129SVDlIRFtZf2qv7-14" value="status" style="text;strokeColor=none;fillColor=#d5e8d4;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="uBWajqLBtvn8ZttVkuIT-12" vertex="1">
          <mxGeometry y="146" width="188.75" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-1" value="Implemented problem" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=30;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;fillColor=#fff2cc;strokeColor=#d6b656;" parent="1" vertex="1">
          <mxGeometry x="430" y="-724" width="175" height="234" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-2" value="id PK" style="text;strokeColor=#d6b656;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-1" vertex="1">
          <mxGeometry y="30" width="175" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-3" value="problem_id AK FK" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-1" vertex="1">
          <mxGeometry y="60" width="175" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-4" value="language_id AK FK" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-1" vertex="1">
          <mxGeometry y="90" width="175" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-5" value="problem_code" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-1" vertex="1">
          <mxGeometry y="120" width="175" height="30" as="geometry" />
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-3" value="default_solution_code" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" vertex="1" parent="4oMAL4PlvlQO6XESmOgE-1">
          <mxGeometry y="150" width="175" height="30" as="geometry" />
        </mxCell>
        <mxCell id="UhVVKJ6M58BYNUrVJEnD-1" value="working_solution_code&amp;nbsp;" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-1" vertex="1">
          <mxGeometry y="180" width="175" height="24" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-63" value="createInfo ActionInfo&lt;i&gt;&lt;br&gt;&lt;/i&gt;" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-1" vertex="1">
          <mxGeometry y="204" width="175" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-7" value="Testcase" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;fillColor=#fff2cc;strokeColor=#d6b656;" parent="1" vertex="1">
          <mxGeometry x="430" y="-988" width="210" height="176" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-8" value="id PK" style="text;strokeColor=#d6b656;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-7" vertex="1">
          <mxGeometry y="26" width="210" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-9" value="problem_id AK FK" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-7" vertex="1">
          <mxGeometry y="56" width="210" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-10" value="input AK - json в виде строки" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-7" vertex="1">
          <mxGeometry y="86" width="210" height="30" as="geometry" />
        </mxCell>
        <mxCell id="4oMAL4PlvlQO6XESmOgE-11" value="output - json в виде строки" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-7" vertex="1">
          <mxGeometry y="116" width="210" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-147" value="createInfo ActionInfo" style="text;strokeColor=none;fillColor=#fff2cc;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="4oMAL4PlvlQO6XESmOgE-7" vertex="1">
          <mxGeometry y="146" width="210" height="30" as="geometry" />
        </mxCell>
        <mxCell id="UhVVKJ6M58BYNUrVJEnD-2" value="Language" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;strokeColor=#b85450;fillColor=#f8cecc;" parent="1" vertex="1">
          <mxGeometry x="725" y="-724" width="235" height="146" as="geometry" />
        </mxCell>
        <mxCell id="UhVVKJ6M58BYNUrVJEnD-3" value="id PK" style="text;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;strokeColor=#b85450;fillColor=#f8cecc;" parent="UhVVKJ6M58BYNUrVJEnD-2" vertex="1">
          <mxGeometry y="26" width="235" height="30" as="geometry" />
        </mxCell>
        <mxCell id="UhVVKJ6M58BYNUrVJEnD-4" value="language_name AK" style="text;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;strokeColor=none;fillColor=#f8cecc;" parent="UhVVKJ6M58BYNUrVJEnD-2" vertex="1">
          <mxGeometry y="56" width="235" height="30" as="geometry" />
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-1" value="default_problem_code" style="text;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;strokeColor=none;fillColor=#f8cecc;" vertex="1" parent="UhVVKJ6M58BYNUrVJEnD-2">
          <mxGeometry y="86" width="235" height="30" as="geometry" />
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-2" value="default_solution_code" style="text;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;strokeColor=none;fillColor=#f8cecc;" vertex="1" parent="UhVVKJ6M58BYNUrVJEnD-2">
          <mxGeometry y="116" width="235" height="30" as="geometry" />
        </mxCell>
        <mxCell id="UhVVKJ6M58BYNUrVJEnD-8" value="" style="endArrow=ERoneToMany;html=1;rounded=0;exitX=1;exitY=0.5;exitDx=0;exitDy=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;startArrow=ERone;startFill=0;endFill=0;" parent="1" source="uBWajqLBtvn8ZttVkuIT-2" target="4oMAL4PlvlQO6XESmOgE-3" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="450" y="-590" as="sourcePoint" />
            <mxPoint x="420" y="-670" as="targetPoint" />
            <Array as="points">
              <mxPoint x="400" y="-679" />
              <mxPoint x="400" y="-649" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="UhVVKJ6M58BYNUrVJEnD-9" value="" style="endArrow=ERoneToMany;html=1;rounded=0;exitX=0.987;exitY=0.286;exitDx=0;exitDy=0;exitPerimeter=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;endFill=0;startArrow=ERone;startFill=0;" parent="1" source="uBWajqLBtvn8ZttVkuIT-2" target="4oMAL4PlvlQO6XESmOgE-9" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="450" y="-770" as="sourcePoint" />
            <mxPoint x="610" y="-770" as="targetPoint" />
            <Array as="points">
              <mxPoint x="400" y="-685" />
              <mxPoint x="400" y="-917" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="UhVVKJ6M58BYNUrVJEnD-10" value="" style="endArrow=ERone;html=1;rounded=0;exitX=1;exitY=0.5;exitDx=0;exitDy=0;endFill=0;startArrow=ERzeroToMany;startFill=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;" parent="1" source="4oMAL4PlvlQO6XESmOgE-4" target="UhVVKJ6M58BYNUrVJEnD-3" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="450" y="-710" as="sourcePoint" />
            <mxPoint x="685" y="-660" as="targetPoint" />
            <Array as="points">
              <mxPoint x="685" y="-620" />
              <mxPoint x="685" y="-683" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-36" value="User/Person" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="190" y="-1070" width="160" height="266" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-37" value="id PK" style="text;strokeColor=default;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-46" value="firstName" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="56" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-38" value="lastName" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="86" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-39" value="patronymic null" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="116" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-40" value="nickname" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="146" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-41" value="email" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="176" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-42" value="passwordHash" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="206" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-43" value="birthday" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-36" vertex="1">
          <mxGeometry y="236" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-50" value="Solution test" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="1175" y="-410" width="160" height="176" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-51" value="id PK" style="text;strokeColor=default;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-50" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-52" value="solution_id AK FK" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-50" vertex="1">
          <mxGeometry y="56" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-53" value="testcase_id AK FK" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-50" vertex="1">
          <mxGeometry y="86" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-67" value="date" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-50" vertex="1">
          <mxGeometry y="116" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="_Fd129SVDlIRFtZf2qv7-15" value="status" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="qfu2UGy7fCwkiBcl5-jk-50" vertex="1">
          <mxGeometry y="146" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-58" value="" style="endArrow=ERzeroToMany;html=1;rounded=0;exitX=1;exitY=0.5;exitDx=0;exitDy=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;startArrow=ERone;startFill=0;endFill=0;" parent="1" source="uBWajqLBtvn8ZttVkuIT-13" target="qfu2UGy7fCwkiBcl5-jk-52" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="855" y="-470" as="sourcePoint" />
            <mxPoint x="1015" y="-470" as="targetPoint" />
            <Array as="points">
              <mxPoint x="985" y="-369" />
              <mxPoint x="1145" y="-370" />
              <mxPoint x="1145" y="-339" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="qfu2UGy7fCwkiBcl5-jk-60" value="" style="endArrow=ERone;html=1;rounded=0;entryX=1;entryY=0.5;entryDx=0;entryDy=0;exitX=1;exitY=0.5;exitDx=0;exitDy=0;startArrow=ERzeroToMany;startFill=0;endFill=0;" parent="1" source="qfu2UGy7fCwkiBcl5-jk-53" target="4oMAL4PlvlQO6XESmOgE-8" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="755" y="-550" as="sourcePoint" />
            <mxPoint x="915" y="-550" as="targetPoint" />
            <Array as="points">
              <mxPoint x="1355" y="-310" />
              <mxPoint x="1355" y="-950" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-2" value="Passed test" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="985" y="-151.43" width="160" height="86" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-4" value="used_time" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="27bLTWDcHFSmDADXxaac-2" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-5" value="used_memory" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="27bLTWDcHFSmDADXxaac-2" vertex="1">
          <mxGeometry y="56" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-6" value="Failed with error test" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="1176.26" y="-151.43" width="160" height="56" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-10" value="errorMessage" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="27bLTWDcHFSmDADXxaac-6" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-11" value="Failed with incorrect &#xa;answer test" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=40;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="1365" y="-151.43" width="160" height="70" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-13" value="incorrectAnswerOutput" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="27bLTWDcHFSmDADXxaac-11" vertex="1">
          <mxGeometry y="40" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-15" value="" style="shape=or;whiteSpace=wrap;html=1;rotation=-90;" parent="1" vertex="1">
          <mxGeometry x="1242.5" y="-225.43" width="27.5" height="50" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-16" value="" style="shape=cross;whiteSpace=wrap;html=1;rotation=45;fillColor=#030303;strokeColor=none;" parent="1" vertex="1">
          <mxGeometry x="1239.62" y="-215.51" width="33.27" height="30.16" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-17" value="" style="endArrow=none;html=1;rounded=0;exitX=1;exitY=0.5;exitDx=0;exitDy=0;exitPerimeter=0;entryX=0.499;entryY=0.987;entryDx=0;entryDy=0;entryPerimeter=0;" parent="1" source="27bLTWDcHFSmDADXxaac-15" target="_Fd129SVDlIRFtZf2qv7-15" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="865" y="-255.43" as="sourcePoint" />
            <mxPoint x="1255.5384836300977" y="-234" as="targetPoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-18" value="" style="endArrow=none;html=1;rounded=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;entryPerimeter=0;" parent="1" target="27bLTWDcHFSmDADXxaac-15" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="1062.75" y="-151.43" as="sourcePoint" />
            <mxPoint x="1232.5" y="-271.43" as="targetPoint" />
            <Array as="points">
              <mxPoint x="1062.5" y="-171.43" />
              <mxPoint x="1257.5" y="-171.43" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-19" value="" style="endArrow=none;html=1;rounded=0;exitX=0.5;exitY=0;exitDx=0;exitDy=0;" parent="1" source="27bLTWDcHFSmDADXxaac-6" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="1072.5" y="-271.43" as="sourcePoint" />
            <mxPoint x="1256" y="-180" as="targetPoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-20" value="" style="endArrow=none;html=1;rounded=0;exitX=0;exitY=0.5;exitDx=0;exitDy=0;exitPerimeter=0;entryX=0.5;entryY=0;entryDx=0;entryDy=0;" parent="1" source="27bLTWDcHFSmDADXxaac-15" target="27bLTWDcHFSmDADXxaac-11" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="1072.5" y="-271.43" as="sourcePoint" />
            <mxPoint x="1232.5" y="-271.43" as="targetPoint" />
            <Array as="points">
              <mxPoint x="1256.5" y="-171.43" />
              <mxPoint x="1445" y="-171.43" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-89" value="" style="endArrow=ERzeroToMany;html=1;rounded=0;entryX=0.25;entryY=0;entryDx=0;entryDy=0;exitX=1;exitY=0.5;exitDx=0;exitDy=0;endFill=0;startArrow=ERone;startFill=0;" parent="1" source="27bLTWDcHFSmDADXxaac-63" target="uBWajqLBtvn8ZttVkuIT-12" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="605" y="-475" as="sourcePoint" />
            <mxPoint x="645" y="-370" as="targetPoint" />
            <Array as="points">
              <mxPoint x="752" y="-505" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-117" value="Draft solution" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="180" y="-114.75" width="160" height="56" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-119" value="last_code_update_date" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="27bLTWDcHFSmDADXxaac-117" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-121" value="Working solution" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="377.82" y="-114.75" width="160" height="56" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-123" value="submittedAt" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="27bLTWDcHFSmDADXxaac-121" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-126" value="Not working solution" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="585" y="-114.75" width="160" height="60" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-128" value="submittedAt" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="27bLTWDcHFSmDADXxaac-126" vertex="1">
          <mxGeometry y="26" width="160" height="34" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-134" value="" style="shape=or;whiteSpace=wrap;html=1;rotation=-90;" parent="1" vertex="1">
          <mxGeometry x="785.63" y="-185.35000000000002" width="27.5" height="50" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-135" value="" style="shape=cross;whiteSpace=wrap;html=1;rotation=45;fillColor=#030303;strokeColor=none;" parent="1" vertex="1">
          <mxGeometry x="782.7499999999999" y="-175.43" width="33.27" height="30.16" as="geometry" />
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-136" value="" style="endArrow=none;html=1;rounded=0;exitX=1;exitY=0.5;exitDx=0;exitDy=0;exitPerimeter=0;entryX=0.5;entryY=1;entryDx=0;entryDy=0;" parent="1" source="27bLTWDcHFSmDADXxaac-134" target="uBWajqLBtvn8ZttVkuIT-12" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="735" y="-200" as="sourcePoint" />
            <mxPoint x="800" y="-230" as="targetPoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-138" value="" style="endArrow=none;html=1;rounded=0;exitX=0.5;exitY=0;exitDx=0;exitDy=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;entryPerimeter=0;" parent="1" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="255" y="-114.75" as="sourcePoint" />
            <mxPoint x="799.3699999999999" y="-150.00000000000006" as="targetPoint" />
            <Array as="points">
              <mxPoint x="255" y="-133.32" />
              <mxPoint x="799" y="-133.32" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-139" value="" style="endArrow=none;html=1;rounded=0;exitX=0.5;exitY=0;exitDx=0;exitDy=0;" parent="1" source="27bLTWDcHFSmDADXxaac-121" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="495" y="-103.32" as="sourcePoint" />
            <mxPoint x="458" y="-133.32" as="targetPoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="27bLTWDcHFSmDADXxaac-140" value="" style="endArrow=none;html=1;rounded=0;exitX=0.5;exitY=0;exitDx=0;exitDy=0;" parent="1" source="27bLTWDcHFSmDADXxaac-126" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="495" y="-103.32" as="sourcePoint" />
            <mxPoint x="665" y="-133.32" as="targetPoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="_Fd129SVDlIRFtZf2qv7-7" value="Open problem" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="283.75" y="-362" width="160" height="56" as="geometry" />
        </mxCell>
        <mxCell id="_Fd129SVDlIRFtZf2qv7-8" value="openInfo ActionInfo?" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="_Fd129SVDlIRFtZf2qv7-7" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="aDxvkXDtERVIUQvnmX8f-5" value="Draft problem" style="swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;align=center;fontSize=14;" parent="1" vertex="1">
          <mxGeometry x="95.48" y="-362" width="160" height="56" as="geometry" />
        </mxCell>
        <mxCell id="aDxvkXDtERVIUQvnmX8f-6" value="updateInfo ActionInfo?" style="text;strokeColor=none;fillColor=none;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;fontSize=12;whiteSpace=wrap;html=1;" parent="aDxvkXDtERVIUQvnmX8f-5" vertex="1">
          <mxGeometry y="26" width="160" height="30" as="geometry" />
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-5" value="" style="shape=or;whiteSpace=wrap;html=1;rotation=-90;" vertex="1" parent="1">
          <mxGeometry x="256.25" y="-430.08" width="27.5" height="50" as="geometry" />
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-6" value="" style="shape=cross;whiteSpace=wrap;html=1;rotation=45;fillColor=#030303;strokeColor=none;" vertex="1" parent="1">
          <mxGeometry x="255.4799999999999" y="-420.15999999999997" width="33.27" height="30.16" as="geometry" />
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-9" value="" style="endArrow=none;html=1;rounded=0;exitX=0.5;exitY=0;exitDx=0;exitDy=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;entryPerimeter=0;" edge="1" parent="1" source="aDxvkXDtERVIUQvnmX8f-5" target="Dj5LCuiiQ5axlCu7R4xd-5">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="240" y="-410" as="sourcePoint" />
            <mxPoint x="400" y="-410" as="targetPoint" />
            <Array as="points">
              <mxPoint x="175" y="-380" />
              <mxPoint x="270" y="-380" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-11" value="" style="endArrow=none;html=1;rounded=0;exitX=0;exitY=0.5;exitDx=0;exitDy=0;exitPerimeter=0;entryX=0.5;entryY=0;entryDx=0;entryDy=0;" edge="1" parent="1" source="Dj5LCuiiQ5axlCu7R4xd-5" target="_Fd129SVDlIRFtZf2qv7-7">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="190" y="-360" as="sourcePoint" />
            <mxPoint x="350" y="-360" as="targetPoint" />
            <Array as="points">
              <mxPoint x="270" y="-380" />
              <mxPoint x="364" y="-380" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="Dj5LCuiiQ5axlCu7R4xd-12" value="" style="endArrow=none;html=1;rounded=0;exitX=0.497;exitY=1.031;exitDx=0;exitDy=0;exitPerimeter=0;entryX=1;entryY=0.5;entryDx=0;entryDy=0;entryPerimeter=0;" edge="1" parent="1" source="aDxvkXDtERVIUQvnmX8f-3" target="Dj5LCuiiQ5axlCu7R4xd-5">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="170" y="-400" as="sourcePoint" />
            <mxPoint x="330" y="-400" as="targetPoint" />
          </mxGeometry>
        </mxCell>
      </root>
    </mxGraphModel>
  </diagram>
</mxfile>
